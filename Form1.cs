using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Friendly_Betrayal
{
    public partial class Form1 : Form
    {
        private Deck deck = new Deck(); // Oyun içinde kullanılacak deste
        private bool first_tour = false; // İlk turu kontrol etmek için
        private int remaining = 52; // Kalan kart sayısı
        private int currentCardIndex = 0; // Kart dağıtımı için başlangıç indeksi
        private int currentPlayerIndex = 0; // Şu anki oyuncuyu takip etmek için (0: User1, 1: User2, 2: User3, 3: User4)
        private int tour_count = 0; // Tur sayısını takip eder
        private List<Card> distribution_card = new List<Card>();
        private List<Card> equal_card = new List<Card>();

        public Form1()
        {
            InitializeComponent();
        }

        public class Card
        {
            public string value;
            public string kind;
            public string image_path;

            public Card(string _value, string _kind)
            {
                this.value = _value;
                this.kind = _kind;
                this.image_path = $"{_kind}of{_value}.png";
            }

            // Kartın değerlerini göstermek için
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

        public class Deck
        {
            public List<Card> deck_cards = new List<Card>();

            string[] card_class = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
            string[] card_value = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

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

            public List<Card> GetCards()
            {
                return deck_cards;
            }

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

        private bool AreAllPlayersOutOfCards()
        {
            return cmb_Box1.Items.Count == 0 && cmb_Box2.Items.Count == 0 && cmb_Box3.Items.Count == 0 && cmb_Box4.Items.Count == 0;
        }

        private void btn_deal_Click(object sender, EventArgs e)
        {
            if (!first_tour) // ilk tursa
            {
                deck.Shuffle(); // İlk turda deste karıştırılıyor

                // İlk 4 kartı ortaya açıyoruz
                for (int i = 0; i < 4; i++)
                {
                    Card temp_card = deck.GetCards()[i];
                    revealedCards.Items.Add(temp_card); // Kartı ListBox'a ekliyoruz
                    remaining--;
                }
                currentCardIndex = 4; // 4 kart ortaya açıldıktan sonra kalan kartları dağıtmaya devam etmek için index'i 4 yapıyoruz.
                first_tour = true; // İlk tur tamamlandı
            }
            else // ilk tur değilse
            {
                tour_count++;

                // Her turda 4 kart dağıtıyoruz
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

                // UI'ı güncelliyoruz
                label1.Text = "Dağıtılan Kart Sayısı: " + ((52 - remaining) - 4); // Ortaya açılan 4 kart hariç dağıtılan kart sayısı
                label2.Text = "Tur Sayısı: " + tour_count;

                btn_deal.Enabled = false; // Kart dağıtıldıktan sonra butonu devre dışı bırak
            }
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            Card selectedCard = null;
            Card selectedRevealed = null;
            Card selectedDiscarded = null;
            Card matchingRevealedCard = null;
            Card selectedUser1 = null;
            Card selectedUser2 = null;
            Card selectedUser3 = null;
            Card selectedUser4 = null;


            // Check if there's a selected item in revealedCards ListBox
            if (revealedCards.SelectedItem != null)
            {
                selectedRevealed = revealedCards.SelectedItem as Card;
            }

            // Check if there's a selected item in discardedCards ListBox
            if (discardedCards.SelectedItem != null)
            {
                selectedDiscarded = discardedCards.Items[0] as Card;
            }
            // Check if there's a selected item in BetrayalCards1 ListBox
            if (selectedUser1 != null) {
                selectedUser1 = BetrayalCards1.SelectedItem as Card;
            }
            // Check if there's a selected item in BetrayalCards2 ListBox
            if (selectedUser2 != null) {
                selectedUser2 = BetrayalCards2.SelectedItem as Card;
            }
            // Check if there's a selected item in BetrayalCards3 ListBox
            if (selectedUser3 != null) {
                selectedUser3 = BetrayalCards3.SelectedItem as Card;
            }
            // Check if there's a selected item in BetrayalCards4 ListBox
            if (selectedUser4 != null) {
                selectedUser4 = BetrayalCards4.SelectedItem as Card;
            }


            // Handle the current player's selected card
            switch (currentPlayerIndex)
            {
                case 0:
                    if (cmb_Box1.SelectedItem != null)
                    {
                        selectedCard = cmb_Box1.SelectedItem as Card;
                        cmb_Box1.Items.Remove(selectedCard); // Remove selected card from ComboBox
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

            if (selectedCard != null)
            {
                if (selectedRevealed != null && selectedCard.value == selectedRevealed.value)
                {
                    // Iterate through revealedCards to check if there are any other cards with the same value
                    foreach (Card card in revealedCards.Items)
                    {
                        if (card.value == selectedRevealed.value && card != selectedRevealed)
                        {
                            matchingRevealedCard = card;
                            distribution_card.Add(matchingRevealedCard);
                        }
                    }

                    if (matchingRevealedCard != null)
                    {
                        // If another matching card is found, handle it
                        distribution_card.Add(selectedCard);
                        distribution_card.Add(matchingRevealedCard);
                        revealedCards.Items.Remove(matchingRevealedCard); // Remove the matching revealed card
                        revealedCards.Items.Remove(selectedRevealed); // Remove the original revealed card
                        BetrayMiddle(distribution_card);
                    }
                    else
                    {
                        // Handle the case where only one matching card is found
                        distribution_card.Add(selectedCard);
                        distribution_card.Add(selectedRevealed);
                        revealedCards.Items.Remove(selectedRevealed); // Remove the original revealed card
                        BetrayMiddle(distribution_card);
                    }
                }
                else if (selectedDiscarded != null && selectedCard.value == selectedDiscarded.value)
                {
                    distribution_card.Add(selectedCard);
                    distribution_card.Add(selectedDiscarded);
                    discardedCards.Items.Remove(selectedDiscarded); // Remove the discarded card
                    BetrayMiddle(distribution_card);
                }
                else
                {
                    discardedCards.Items.Insert(0, selectedCard);
                }

                // Pass the turn to the next player
                currentPlayerIndex = (currentPlayerIndex + 1) % 4;
                distribution_card.Clear();
            }

            // Re-enable the deal button if all players are out of cards
            if (AreAllPlayersOutOfCards())
            {
                btn_deal.Enabled = true;
            }
        }


        private void BetrayMiddle(List<Card> cards)
        {
            // Ensure a player is selected from the comboBox
            if (comboBox_Stake.SelectedItem == null)
            {
                MessageBox.Show("No player selected for betrayal.");
                return;
            }

            string user = comboBox_Stake.SelectedItem.ToString();

            // Switch statement to handle which user's betrayal pile to add the cards to
            switch (user)
            {
                case "User1":
                    foreach (Card card in cards)
                    {
                        BetrayalCards1.Items.Add(card);
                    }
                    break;

                case "User2":
                    foreach (Card card in cards)
                    {
                        BetrayalCards2.Items.Add(card);
                    }
                    break;

                case "User3":
                    foreach (Card card in cards)
                    {
                        BetrayalCards3.Items.Add(card);
                    }
                    break;

                case "User4":
                    foreach (Card card in cards)
                    {
                        BetrayalCards4.Items.Add(card);
                    }
                    break;

                default:
                    MessageBox.Show("Invalid user selection.");
                    break;
            }

            // Optional: Display a confirmation message or perform additional actions
            MessageBox.Show("Betray action completed. The selected cards have been added to the betrayal pile of " + user + ".");
        }
    }
}
