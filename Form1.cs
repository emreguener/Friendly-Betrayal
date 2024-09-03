using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Friendly_Betrayal
{
    public partial class Form1 : Form
    {
        // Oyunda kullanılacak desteyi tanımlar
        private Deck deck = new Deck();

        // İlk tur olup olmadığını kontrol eder
        private bool first_tour = false;

        // Kalan kart sayısını takip eder
        private int remaining = 52;

        // Kart dağıtımı için başlangıç indeksini belirler
        private int currentCardIndex = 0;

        // Şu anki oyuncuyu takip eder (0: User1, 1: User2, 2: User3, 3: User4)
        private int currentPlayerIndex = 0;

        // Tur sayısını takip eder
        private int tour_count = 0;

        // Dağıtılan kartları geçici olarak saklamak için liste
        private List<Card> distribution_card = new List<Card>();

        private int User1_Point = 0;
        private int User2_Point = 0;
        private int User3_Point = 0;
        private int User4_Point = 0;

        public Form1()
        {
            InitializeComponent();

            // ListBox'ların seçim olaylarına aynı anda sadece bir tanesinin seçilmesini sağlamak için olay dinleyicileri eklenir
            revealedCards.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            discardedCards.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            BetrayalCards1.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            BetrayalCards2.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            BetrayalCards3.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            BetrayalCards4.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            UpdateComboBoxStake();
        }

        // Aynı anda sadece bir ListBox'tan kart seçilmesini sağlar
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hangi ListBox'tan seçim yapılmadıysa, onun seçimini temizler
            if (sender != revealedCards) revealedCards.ClearSelected();
            if (sender != discardedCards) discardedCards.ClearSelected();
            if (sender != BetrayalCards1) BetrayalCards1.ClearSelected();
            if (sender != BetrayalCards2) BetrayalCards2.ClearSelected();
            if (sender != BetrayalCards3) BetrayalCards3.ClearSelected();
            if (sender != BetrayalCards4) BetrayalCards4.ClearSelected();
        }

        // Kart sınıfı, her bir kartın özelliklerini tanımlar
        public class Card
        {
            public string value; // Kartın değeri (As, 2, 3,..., Papaz)
            public string kind; // Kartın türü (Maça, Kupa, Karo, Sinek)
            public string image_path; // Kartın resim yolu

            // Kartın özelliklerini alan yapıcı (constructor)
            public Card(string _value, string _kind)
            {
                this.value = _value;
                this.kind = _kind;
                this.image_path = $"{_kind}of{_value}.png";
            }

            // Kartın metin olarak gösterilmesi için
            public override string ToString()
            {
                return $"{value} of {kind}";
            }

            // Kartın resim yolunu almak için
            public string GetImagePath()
            {
                return $"{image_path}";
            }
        }

        // Deste sınıfı, oyun için 52 kartlık bir desteyi oluşturur ve karıştırma işlevini sağlar
        public class Deck
        {
            public List<Card> deck_cards = new List<Card>(); // Desteyi temsil eden kart listesi

            // Kart türlerini ve değerlerini tanımlayan diziler
            string[] card_class = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
            string[] card_value = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            // Deste yapıcısı, 52 kartı oluşturur
            public Deck()
            {
                for (int i = 0; i < card_class.Length; i++)
                {
                    for (int j = 0; j < card_value.Length; j++)
                    {
                        Card temp = new Card(card_value[j], card_class[i]);
                        deck_cards.Add(temp);
                    }
                }
            }

            // Destede bulunan kartları döndürür
            public List<Card> GetCards()
            {
                return deck_cards;
            }

            // Kartları rastgele sıraya sokmak için karıştırma işlevi
            public void Shuffle()
            {
                Random rng = new Random();
                int n = deck_cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Card value = deck_cards[k];
                    deck_cards[k] = deck_cards[n];
                    deck_cards[n] = value;
                }
            }
        }

        // Tüm oyuncuların kartlarının bitip bitmediğini kontrol eder
        private bool AreAllPlayersOutOfCards()
        {
            return cmb_Box1.Items.Count == 0 && cmb_Box2.Items.Count == 0 && cmb_Box3.Items.Count == 0 && cmb_Box4.Items.Count == 0;
        }

        // Kartları dağıtan butonun işlevi
        private void btn_deal_Click(object sender, EventArgs e)
        {
            if (!first_tour) // Eğer ilk tursa
            {
                deck.Shuffle(); // Deste karıştırılır

                // İlk 4 kartı açarak ortaya koyar
                for (int i = 0; i < 4; i++)
                {
                    Card temp_card = deck.GetCards()[i];
                    revealedCards.Items.Add(temp_card); // Kartı ListBox'a ekler
                    remaining--;
                }
                currentCardIndex = 4; // 4 kart açıldıktan sonra kalan kartlar için indeks 4 olarak ayarlanır
                first_tour = true; // İlk tur tamamlandı
            }
            else // Eğer ilk tur değilse
            {
                tour_count++;

                // Her turda 4 kart dağıtır
                for (int j = 0; j < 16 && currentCardIndex < 52; j++)
                {
                    Card temp_card = deck.GetCards()[currentCardIndex];
                    switch (currentCardIndex % 4)
                    {
                        case 0:
                            cmb_Box1.Items.Add(temp_card);
                            break;
                        case 1:
                            cmb_Box2.Items.Add(temp_card);
                            break;
                        case 2:
                            cmb_Box3.Items.Add(temp_card);
                            break;
                        case 3:
                            cmb_Box4.Items.Add(temp_card);
                            break;
                    }
                    currentCardIndex++;
                    remaining--;
                }

                // UI güncellenir
                label1.Text = "Dağıtılan Kart Sayısı: " + ((52 - remaining) - 4); // Ortaya açılan 4 kart hariç dağıtılan kart sayısı
                label2.Text = "Tur Sayısı: " + tour_count;

                btn_deal.Enabled = false; // Kart dağıtıldıktan sonra buton devre dışı bırakılır
            }
        }

        // Oyuncunun oyun hamlesini gerçekleştiren işlev
        private void btn_Play_Click(object sender, EventArgs e)
        {
            Card selectedCard = null; // Oyuncunun seçtiği kart
            Card selectedRevealed = null; // Ortaya açılan kartlar arasından seçilen kart
            Card selectedDiscarded = null; // Atılan kartlar arasından seçilen kart
            Card selectedUser1 = null; // User1'in seçilen kartı
            Card selectedUser2 = null; // User2'nin seçilen kartı
            Card selectedUser3 = null; // User3'ün seçilen kartı
            Card selectedUser4 = null; // User4'ün seçilen kartı

            // Ortaya açılan kartlar arasından bir seçim yapıldı mı kontrol edilir
            if (revealedCards.SelectedItem != null)
            {
                selectedRevealed = revealedCards.SelectedItem as Card;
            }

            // Atılan kartlar arasından bir seçim yapıldı mı kontrol edilir
            if (discardedCards.SelectedItem != null)
            {
                selectedDiscarded = discardedCards.SelectedItem as Card;
            }

            // Kullanıcıların seçilen kartları kontrol edilir
            if (BetrayalCards1.SelectedItem != null)
            {
                selectedUser1 = BetrayalCards1.SelectedItem as Card;
            }
            if (BetrayalCards2.SelectedItem != null)
            {
                selectedUser2 = BetrayalCards2.SelectedItem as Card;
            }
            if (BetrayalCards3.SelectedItem != null)
            {
                selectedUser3 = BetrayalCards3.SelectedItem as Card;
            }
            if (BetrayalCards4.SelectedItem != null)
            {
                selectedUser4 = BetrayalCards4.SelectedItem as Card;
            }

            // Şu anki oyuncunun seçtiği kartı belirler
            switch (currentPlayerIndex)
            {
                case 0:
                    if (cmb_Box1.SelectedItem != null)
                    {
                        selectedCard = cmb_Box1.SelectedItem as Card;
                        cmb_Box1.Items.Remove(selectedCard); // Seçilen kart ComboBox'tan kaldırılır
                    }
                    break;

                case 1:
                    if (cmb_Box2.SelectedItem != null)
                    {
                        selectedCard = cmb_Box2.SelectedItem as Card;
                        cmb_Box2.Items.Remove(selectedCard);
                    }
                    break;

                case 2:
                    if (cmb_Box3.SelectedItem != null)
                    {
                        selectedCard = cmb_Box3.SelectedItem as Card;
                        cmb_Box3.Items.Remove(selectedCard);
                    }
                    break;

                case 3:
                    if (cmb_Box4.SelectedItem != null)
                    {
                        selectedCard = cmb_Box4.SelectedItem as Card;
                        cmb_Box4.Items.Remove(selectedCard);
                    }
                    break;
            }

            if (selectedCard != null) // Eğer oyuncu bir kart seçtiyse
            {
                // Ortaya açılan kartlarla eşleşme mantığı
                if (selectedRevealed != null && selectedCard.value == selectedRevealed.value)
                {
                    // revealedCards içindeki tüm aynı değerdeki kartları topluca taşımak için 
                    for (int i = revealedCards.Items.Count - 1; i >= 0; i--)
                    {
                        Card card = revealedCards.Items[i] as Card;
                        if (card.value == selectedCard.value)
                        {
                            distribution_card.Add(card);
                            revealedCards.Items.RemoveAt(i);
                        }
                    }
                    distribution_card.Add(selectedCard);
                    BetrayMiddle(distribution_card);
                }
                // Atılan kartlarla eşleşme mantığı
                else if (selectedDiscarded != null && selectedCard.value == selectedDiscarded.value)
                {
                    while (discardedCards.Items.Count > 0 && (discardedCards.Items[0] as Card).value == selectedCard.value)
                    {
                        distribution_card.Add(discardedCards.Items[0] as Card);
                        discardedCards.Items.RemoveAt(0);
                    }
                    distribution_card.Add(selectedCard);
                    BetrayMiddle(distribution_card);
                }
                // Kullanıcı 1'in kartlarıyla eşleşme mantığı (sadece üstteki kartlar kontrol edilir)
                else if (selectedUser1 != null && BetrayalCards1.Items.Count > 0 && selectedCard.value == (BetrayalCards1.Items[0] as Card).value)
                {
                    while (BetrayalCards1.Items.Count > 0 && (BetrayalCards1.Items[0] as Card).value == selectedCard.value)
                    {
                        distribution_card.Add(BetrayalCards1.Items[0] as Card);
                        BetrayalCards1.Items.RemoveAt(0);
                    }
                    distribution_card.Add(selectedCard);
                    BetrayMiddle(distribution_card);
                }
                // Kullanıcı 2'nin kartlarıyla eşleşme mantığı (sadece üstteki kartlar kontrol edilir)
                else if (selectedUser2 != null && BetrayalCards2.Items.Count > 0 && selectedCard.value == (BetrayalCards2.Items[0] as Card).value)
                {
                    while (BetrayalCards2.Items.Count > 0 && (BetrayalCards2.Items[0] as Card).value == selectedCard.value)
                    {
                        distribution_card.Add(BetrayalCards2.Items[0] as Card);
                        BetrayalCards2.Items.RemoveAt(0);
                    }
                    distribution_card.Add(selectedCard);
                    BetrayMiddle(distribution_card);
                }
                // Kullanıcı 3'ün kartlarıyla eşleşme mantığı (sadece üstteki kartlar kontrol edilir)
                else if (selectedUser3 != null && BetrayalCards3.Items.Count > 0 && selectedCard.value == (BetrayalCards3.Items[0] as Card).value)
                {
                    while (BetrayalCards3.Items.Count > 0 && (BetrayalCards3.Items[0] as Card).value == selectedCard.value)
                    {
                        distribution_card.Add(BetrayalCards3.Items[0] as Card);
                        BetrayalCards3.Items.RemoveAt(0);
                    }
                    distribution_card.Add(selectedCard);
                    BetrayMiddle(distribution_card);
                }
                // Kullanıcı 4'ün kartlarıyla eşleşme mantığı (sadece üstteki kartlar kontrol edilir)
                else if (selectedUser4 != null && BetrayalCards4.Items.Count > 0 && selectedCard.value == (BetrayalCards4.Items[0] as Card).value)
                {
                    while (BetrayalCards4.Items.Count > 0 && (BetrayalCards4.Items[0] as Card).value == selectedCard.value)
                    {
                        distribution_card.Add(BetrayalCards4.Items[0] as Card);
                        BetrayalCards4.Items.RemoveAt(0);
                    }
                    distribution_card.Add(selectedCard);
                    BetrayMiddle(distribution_card);
                }
                else
                {
                    // Eğer kartlar eşleşmediyse, kartı atılanlar arasına ekle
                    discardedCards.Items.Insert(0, selectedCard);
                }

                // Eğer bir oyuncunun kartları bittiyse ilgili ComboBox'ı temizle
                if (cmb_Box1.Items.Count == 0)
                    cmb_Box1.Items.Clear();
                if (cmb_Box2.Items.Count == 0)
                    cmb_Box2.Items.Clear();
                if (cmb_Box3.Items.Count == 0)
                    cmb_Box3.Items.Clear();
                if (cmb_Box4.Items.Count == 0)
                    cmb_Box4.Items.Clear();

                // Sıradaki oyuncuya geçiş yapar
                currentPlayerIndex = (currentPlayerIndex + 1) % 4;
                UpdateComboBoxStake();
                distribution_card.Clear();
            }

            // Tüm oyuncuların kartları bittiğinde "deal" butonunu tekrar etkinleştirir
            if (AreAllPlayersOutOfCards())
            {
                btn_deal.Enabled = true;
            }
        }

        // Kartları başka bir oyuncunun "betrayal" listesine ekleme işlevi
        private void BetrayMiddle(List<Card> cards)
        {
            // Eğer bir oyuncu seçilmediyse uyarı verir
            if (comboBox_Stake.SelectedItem == null)
            {
                MessageBox.Show("No player selected for betrayal.");
                return;
            }

            string user = comboBox_Stake.SelectedItem.ToString();

            // Seçilen oyuncunun "betrayal" listesine kartları ekler
            switch (user)
            {
                case "User1":
                    foreach (Card card in cards)
                    {
                        BetrayalCards1.Items.Insert(0, card); // En üstteki yere ekle
                    }
                    break;

                case "User2":
                    foreach (Card card in cards)
                    {
                        BetrayalCards2.Items.Insert(0, card); // En üstteki yere ekle
                    }
                    break;

                case "User3":
                    foreach (Card card in cards)
                    {
                        BetrayalCards3.Items.Insert(0, card); // En üstteki yere ekle
                    }
                    break;

                case "User4":
                    foreach (Card card in cards)
                    {
                        BetrayalCards4.Items.Insert(0, card); // En üstteki yere ekle
                    }
                    break;

                default:
                    MessageBox.Show("Invalid user selection.");
                    break;
            }

            // İsteğe bağlı: Bir onay mesajı gösterir veya ek eylemler gerçekleştirir
            MessageBox.Show("Betray action completed. The selected cards have been added to the betrayal pile of " + user + ".");
        }

        private void UpdateComboBoxStake()
        {
            // Önce ComboBox'ı temizler ve tüm oyuncuları ekler
            comboBox_Stake.Items.Clear();
            comboBox_Stake.Items.Add("User1");
            comboBox_Stake.Items.Add("User2");
            comboBox_Stake.Items.Add("User3");
            comboBox_Stake.Items.Add("User4");

            // Sıradaki oyuncuyu ComboBox'tan çıkarır
            switch (currentPlayerIndex)
            {
                case 0:
                    comboBox_Stake.Items.Remove("User1");
                    trn.Text = "Turn: User1";
                    break;
                case 1:
                    comboBox_Stake.Items.Remove("User2");
                    trn.Text = "Turn: User2";
                    break;
                case 2:
                    comboBox_Stake.Items.Remove("User3");
                    trn.Text = "Turn: User3";
                    break;
                case 3:
                    comboBox_Stake.Items.Remove("User4");
                    trn.Text = "Turn: User4";
                    break;
            }

            // İlk eleman varsayılan olarak seçilir
            if (comboBox_Stake.Items.Count > 0)
            {
                comboBox_Stake.SelectedIndex = 0;
            }
        }

        private void EndGameCheck()
        {
            if (remaining == 0 && AreAllPlayersOutOfCards()) // Oyun bittiğinde
            {
                Calculate(); // Puanları hesapla
                DisplayScores(); // Puanları göster
            }
        }

        private void Calculate()
        {
            int listbox_user1 = 0;
            int listbox_user2 = 0;
            int listbox_user3 = 0;
            int listbox_user4 = 0;

            if (remaining == 0 && AreAllPlayersOutOfCards())
            {
                // Kullanıcıların puanlarını hesapla
                foreach (Card card in BetrayalCards1.Items)
                {
                    listbox_user1 += GetCardPointValue(card);
                }
                foreach (Card card in BetrayalCards2.Items)
                {
                    listbox_user2 += GetCardPointValue(card);
                }
                foreach (Card card in BetrayalCards3.Items)
                {
                    listbox_user3 += GetCardPointValue(card);
                }
                foreach (Card card in BetrayalCards4.Items)
                {
                    listbox_user4 += GetCardPointValue(card);
                }

                // Puanları bir listeye koy
                var scores = new List<int> { listbox_user1, listbox_user2, listbox_user3, listbox_user4 };

                // Listeyi sırala (büyükten küçüğe doğru)
                var sortedScores = scores.OrderByDescending(score => score).ToList();

                // Her kullanıcının sıralamasını bul
                int user1Rank = sortedScores.IndexOf(listbox_user1);
                int user2Rank = sortedScores.IndexOf(listbox_user2);
                int user3Rank = sortedScores.IndexOf(listbox_user3);
                int user4Rank = sortedScores.IndexOf(listbox_user4);

                // Puanları dağıt ve doğrudan kullanıcı puanlarını güncelle
                UpdateUserPoints(user1Rank, ref User1_Point);
                UpdateUserPoints(user2Rank, ref User2_Point);
                UpdateUserPoints(user3Rank, ref User3_Point);
                UpdateUserPoints(user4Rank, ref User4_Point);
            }
        }

        private int GetCardPointValue(Card card)
        {
            switch (card.value)
            {
                case "3":
                    return 30;
                case "Jack":
                case "Queen":
                case "King":
                    return 10;
                case "Ace":
                    return 11; // Typical Ace value, adjust if needed
                default:
                    return int.TryParse(card.value, out int val) ? val : 0;
            }
        }

        private void UpdateUserPoints(int rank, ref int userPoints)
        {
            switch (rank)
            {
                case 0:
                    userPoints += 3;
                    break;
                case 1:
                    userPoints += 1;
                    break;
                case 2:
                    userPoints -= 1;
                    break;
                case 3:
                    userPoints -= 3;
                    break;
            }
        }

        private void DisplayScores()
        {
            order.Text = ($"User1 Points: {User1_Point}\nUser2 Points: {User2_Point}\nUser3 Points: {User3_Point}\nUser4 Points: {User4_Point}");
        }
    }
}
