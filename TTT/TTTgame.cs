using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTT
{
    public partial class TTTgame : Form
    {
        //Deklaration der Variablen
        private int activePlayer, XgamesWon, OgamesWon, movesLeft, A1, A2, A3, B1, B2, B3, C1, C2, C3;
        private bool winner, gameIsSingleplayer, gameStoryEnabled, resetFieldOnPlayerCheck;
        DialogResult result; //Variable um das Ergebnis des Dialoges zu speichern



        //Konstruktor mit Parametern
        public TTTgame(bool gameIsSingleplayer, bool gameStoryEnabled) 
        {
            InitializeComponent();
            //Übergebene Variablen von TTTstart
            this.gameIsSingleplayer = gameIsSingleplayer; 
            this.gameStoryEnabled = gameStoryEnabled;
        }

        private void TTTgame_Load(object sender, EventArgs e) //Beim laden des Fensters
        {
            
            //Wenn der Storymodus aktiviert ist wird das Story Fenster vor dem Spiel Angezeigt angezeigt
            if (this.gameStoryEnabled)
            {
                using (var TTTstory = new TTTstory())
                    TTTstory.ShowDialog();
            }
            //Ändert den Titel des Fensters und die Beschriftungen
            if (this.gameIsSingleplayer)
            {
                if (this.gameStoryEnabled)
                {
                    lblPlayer1Name.Text = "Duellant:";
                    lblPlayer2Name.Text = "Endgegner:";
                    this.Text = "Tic-Tac-Toe | Storymodus";
                }
                else
                {
                    lblPlayer1Name.Text = "Spieler:";
                    lblPlayer2Name.Text = "Computer:";
                    this.Text = "Tic-Tac-Toe | Spieler vs. AI";
                }
            }
            else
            {
                lblPlayer1Name.Text = "Kreis:";
                lblPlayer2Name.Text = "Kreuz:";
                this.Text = "Tic-Tac-Toe | Spieler vs. Spieler";
                
            }
             
            //Initialisierung der Variablen
            this.XgamesWon = 0;
            this.OgamesWon = 0;
            this.resetForm();
        }

        private void TTTgame_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void resetForm() //Setzt alle Variablen auf den Standard zurück (Initialisierung / RE-Initialisierung)
        {
            this.activePlayer = 1; //Startspieler ist 1
            this.winner = false; //Das Spiel wurde noch nicht gewonnen
            this.movesLeft = 9; //Zur Abfrage ob Unentschieden gespielt wurde und ob der Computer einen Zug machen soll
            this.resetFieldOnPlayerCheck = false;
          
            //Die Variablen die anzeigen ob und von wem ein Feld belegt ist werden zurückgesetzt
            this.A1 = 0;
            this.A2 = 0;
            this.A3 = 0;
            this.B1 = 0;
            this.B2 = 0;
            this.B3 = 0;
            this.C1 = 0;
            this.C2 = 0;
            this.C3 = 0;
            //Die anzeigen werden zurückgesetzt
            lblPlayer1GamesWon.Text = this.OgamesWon.ToString();
            lblPlayer2GamesWon.Text = this.XgamesWon.ToString();
            //Der Hintergrund der Buttons wird auf null gesetzt 
            button1_1.BackgroundImage = null;
            button1_2.BackgroundImage = null;
            button1_3.BackgroundImage = null;
            button2_1.BackgroundImage = null;
            button2_2.BackgroundImage = null;
            button2_3.BackgroundImage = null;
            button3_1.BackgroundImage = null;
            button3_2.BackgroundImage = null;
            button3_3.BackgroundImage = null;
            //Die Buttons werden aktiviert
            button1_1.Enabled = true;
            button1_2.Enabled = true;
            button1_3.Enabled = true;
            button2_1.Enabled = true;
            button2_2.Enabled = true;
            button2_3.Enabled = true;
            button3_1.Enabled = true;
            button3_2.Enabled = true;
            button3_3.Enabled = true;
        }//Ende von resetGame()

        //Button Klick Events (Der Ordnung halber auf jeweils eine Zeile reduziert)
        private void button1_1_Click(object sender, EventArgs e) { buttonClick(1); }
        private void button1_2_Click(object sender, EventArgs e) { buttonClick(2); }
        private void button1_3_Click(object sender, EventArgs e) { buttonClick(3); }
        private void button2_1_Click(object sender, EventArgs e) { buttonClick(4); }
        private void button2_2_Click(object sender, EventArgs e) { buttonClick(5); }
        private void button2_3_Click(object sender, EventArgs e) { buttonClick(6); }
        private void button3_1_Click(object sender, EventArgs e) { buttonClick(7); }
        private void button3_2_Click(object sender, EventArgs e) { buttonClick(8); }
        private void button3_3_Click(object sender, EventArgs e) { buttonClick(9); }

        private void buttonClick(int buttonNumber) 
        {
            //Anzahl der verbleibenden Züge wird um 1 reduziert
            this.movesLeft--;
            //Je nach übergebenem Wert den entsprechenden Button ändern und deaktivieren
            switch (buttonNumber) 
            {
                case 1: //Wenn das Feld Nummer 1 angeklickt wurde
                    if (this.activePlayer == 1) //Wenn spieler 1 am Zug ist
                        button1_1.BackgroundImage = Properties.Resources.O; //Ändere den Hintergrund zu einem O
                    else //Wenn Spieler 2 am Zug ist  
                        button1_1.BackgroundImage = Properties.Resources.X; //Ändere den Hintergrund zu einem X
                    this.A1 = this.activePlayer; //Die Variable die dem Feld entspricht wird auf den Wert des aktuellen spielers gesetzt um den gewinner zu bestimmen
                    button1_1.Enabled = false; //Der Button wird deaktiviert damit er nicht erneut angeklickt werden kann
                    break;
                case 2:
                    if (this.activePlayer == 1)
                        button1_2.BackgroundImage = Properties.Resources.O;
                    else
                        button1_2.BackgroundImage = Properties.Resources.X;
                    this.A2 = this.activePlayer;
                    button1_2.Enabled = false;
                    break;
                case 3:
                    if (this.activePlayer == 1)
                        button1_3.BackgroundImage = Properties.Resources.O;
                    else
                        button1_3.BackgroundImage = Properties.Resources.X;
                    this.A3 = this.activePlayer;
                    button1_3.Enabled = false;
                    break;
                case 4:
                    if (this.activePlayer == 1)
                        button2_1.BackgroundImage = Properties.Resources.O;
                    else
                        button2_1.BackgroundImage = Properties.Resources.X;
                    this.B1 = this.activePlayer;
                    button2_1.Enabled = false;
                    break;
                case 5:
                    if (this.activePlayer == 1)
                        button2_2.BackgroundImage = Properties.Resources.O;
                    else
                        button2_2.BackgroundImage = Properties.Resources.X;
                    this.B2 = this.activePlayer;
                    button2_2.Enabled = false;
                    break;
                case 6:
                    if (this.activePlayer == 1)
                        button2_3.BackgroundImage = Properties.Resources.O;
                    else
                        button2_3.BackgroundImage = Properties.Resources.X;
                    this.B3 = this.activePlayer;
                    button2_3.Enabled = false;
                    break;
                case 7:
                    if (this.activePlayer == 1)
                        button3_1.BackgroundImage = Properties.Resources.O;
                    else
                        button3_1.BackgroundImage = Properties.Resources.X;
                    this.C1 = this.activePlayer;
                    button3_1.Enabled = false;
                    break;
                case 8:
                    if (this.activePlayer == 1)
                        button3_2.BackgroundImage = Properties.Resources.O;
                    else
                        button3_2.BackgroundImage = Properties.Resources.X;
                    this.C2 = this.activePlayer;
                    button3_2.Enabled = false;
                    break;
                case 9:
                    if (this.activePlayer == 1)
                        button3_3.BackgroundImage = Properties.Resources.O;
                    else
                        button3_3.BackgroundImage = Properties.Resources.X;
                    this.C3 = this.activePlayer;
                    button3_3.Enabled = false;
                    break;
                default: //Dieser Case sollte eigentlich niemals auftreten
                    MessageBox.Show("Es ist ein Fehler aufgetreten\nEs wurde kein freies Feld gefunden", "ERROR", MessageBoxButtons.OK);
                    this.Close();
                    break;
            }
            //Auf Gewinner prüfen
            //Horizontale Linien
            if ((this.A1 == this.A2) && (this.A1 == this.A3) && (!button1_1.Enabled))
                this.winner = true;
            else
                if ((this.B1 == this.B2) && (this.B1 == this.B3) && (!button2_1.Enabled))
                    this.winner = true;
                else
                    if ((this.C1 == this.C2) && (this.C1 == this.C3) && (!button3_1.Enabled))
                        this.winner = true;

            //Vertikale Linien
                    else
                        if ((this.A1 == this.B1) && (this.A1 == this.C1) && (!button1_1.Enabled))
                            this.winner = true;
                        else
                            if ((this.A2 == this.B2) && (this.A2 == this.C2) && (!button1_2.Enabled))
                                this.winner = true;
                            else
                                if ((this.A3 == this.B3) && (this.A3 == this.C3) && (!button1_3.Enabled))
                                    this.winner = true;

            //Diagonale Linien
                                else
                                    if ((this.A1 == this.B2) && (this.A1 == this.C3) && (!button1_1.Enabled))
                                        this.winner = true;
                                    else
                                        if ((this.A3 == this.B2) && (this.A3 == this.C1) && (!button1_3.Enabled))
                                            this.winner = true;
            //Ende des Gewinner Prüfers
            //Ändert den Punktestand
            if (this.winner)
            {
                if (this.activePlayer == 1)
                    this.OgamesWon++;
                if (this.activePlayer == 2)
                    this.XgamesWon++;
                lblPlayer1GamesWon.Text = this.OgamesWon.ToString();
                lblPlayer2GamesWon.Text = this.XgamesWon.ToString();
            }

            //GameOver Nachrichten
            if (this.gameStoryEnabled) //Wenn die Story gespielt wird
            {
                if (this.XgamesWon == 5 || this.OgamesWon == 5) //Wenn das Spiel limit erreicht wurde
                {
                    if (this.OgamesWon > this.XgamesWon) //Wenn der Spieler gewinnt
                    {
                        //OEnd Fenster
                        using (var TTTOEnd = new TTTOEnd())
                        {
                            TTTOEnd.ShowDialog();
                        }
                        this.Close();
                    }
                    else
                    {
                        if (this.XgamesWon > this.OgamesWon) //Wenn der Computer gewinnt
                        {
                            //XEnd Fenster
                            using (var TTTXEnd = new TTTXEnd())
                            {
                                TTTXEnd.ShowDialog();
                            }
                            this.Close();
                        }
                    }
                }
                else //Wenn das Spiellimit noch nicht erreicht wurde
                {
                    if (this.winner) //Wenn es einen Gewinner gibt
                    {
                        if (this.activePlayer == 1) //Wenn Spieler 1 am Zug war
                        {
                            MessageBox.Show("Der Duellant einen Punkt gemacht!", "Gewonnen!", MessageBoxButtons.OK);
                            this.resetFieldOnPlayerCheck = true;
                        }
                        else
                        {
                            if (this.activePlayer == 2) //Wenn Spieler 2 am Zug war
                            {
                                MessageBox.Show("Der Endgegner hat einen Punkt gemacht!", "Verloren!", MessageBoxButtons.OK);
                                this.resetFieldOnPlayerCheck = true;
                            }
                        }
                    }
                    else
                    {
                        if (this.movesLeft == 0) //Wenn keine Züge mehr übrig sind
                        {
                            //Nachticht dass Unentschieden gespielt wurde
                            MessageBox.Show("Es wurde Unentschieden gespielt!", "Gewonnen!", MessageBoxButtons.OK);
                            this.resetFieldOnPlayerCheck = true;
                        }
                    }
                }
            }
            else
            {
                if (this.gameIsSingleplayer) //Wenn das Spiel alleine gegen den Computer gespielt wird
                {
                    if (this.winner) //Wenn ein Spieler gewonnen hat
                    {
                        if (this.activePlayer == 1) //Wenn der Spieler gewinnt
                        {
                            //Spieler hat gegen AI gewonnen
                            result = MessageBox.Show("Diesmal haben sie gegen den Computer gewonnen!\nWollen sie es nochmal Versuchen?", "Gewonnen!", MessageBoxButtons.YesNo);
                            if (this.result == DialogResult.Yes)
                            {
                                this.resetFieldOnPlayerCheck = true;
                            }
                            else
                                this.Close();
                        }
                        if (this.activePlayer == 2) //Wenn der Computer gewinnt
                        {
                            //AI gewinnt gegen Spieler
                            result = MessageBox.Show("Der Computer hat gewonnen!\nWollen sie nochmal verlieren?", "Verloren!", MessageBoxButtons.YesNo);
                            if (this.result == DialogResult.Yes)
                            {
                                this.resetFieldOnPlayerCheck = true;
                            }
                            else
                                this.Close();
                        }
                    }
                    else
                    {
                        if (this.movesLeft == 0) //Wenn es keinen Gewinner gibt aber keine Züge mehr gemacht werden können
                        {
                            //Unentschieden Nachricht
                            result = MessageBox.Show("Unentschieden!\nWollen sie es nochmal versuchen?", "Verloren!", MessageBoxButtons.YesNo);
                            if (this.result == DialogResult.Yes)
                            {
                                this.resetFieldOnPlayerCheck = true;
                            }
                            else
                                this.Close();
                        }
                    }
                }
                else //Wenn das Spiel im Multiplayer gespielt wird
                {
                    if (this.winner) //Wenn es einen Gewinner gibt
                    {
                        if (this.activePlayer == 1) //Wenn Kreis gewinnt
                        {
                            //Kreis gewinnt
                            result = MessageBox.Show("Kreis hat gewonnen!\nNochmal?", "Kreis ist der Gewinner!", MessageBoxButtons.YesNo);
                            if (this.result == DialogResult.Yes)
                            {
                                this.resetFieldOnPlayerCheck = true;
                            }
                            else
                                this.Close();
                        }
                        else
                        {
                            if (this.activePlayer == 2) //Wenn Kreuz gewinnt
                            {
                                //Kreuz gewinnt
                                result = MessageBox.Show("Kreuz hat gewonnen!\nNochmal?", "Kreuz ist der Gewinner!", MessageBoxButtons.YesNo);
                                if (this.result == DialogResult.Yes)
                                {
                                    this.resetFieldOnPlayerCheck = true;
                                }
                                else
                                    this.Close();
                            }
                        }

                    }
                    else
                    {
                        if (this.movesLeft == 0) //Wenn es keinen Gewinner gibt aber keine Züge mehr gemacht werden können
                        {
                            //Unentschieden
                            result = MessageBox.Show("Niemand hat gewonnen!\nNochmal?", "Unentschieden!", MessageBoxButtons.YesNo);
                            if (this.result == DialogResult.Yes)
                            {
                                this.resetFieldOnPlayerCheck = true;
                            }
                            else
                                this.Close();
                        }
                    }
                }
            }

            //Wenn noch Züge übrig sind und nicht gerade zurückgesetzt wurde
            if (this.movesLeft > 0 && !this.resetFieldOnPlayerCheck) 
            {
                //Den Spieler wechseln
                if (this.activePlayer == 1)
                    this.activePlayer = 2;
                else
                    this.activePlayer = 1;
                //Den Computer einen Zug machen lassen wenn so ausgewählt wurde und er am Zug ist
                if (this.gameIsSingleplayer && this.activePlayer == 2 && this.movesLeft > 0)
                    computerMakeMove();
            }
            else
            {
                if (this.resetFieldOnPlayerCheck) //wenn
                    resetForm();
            }
            if (this.activePlayer == 1)
            {
                lblPlayer.Text = "Kreis ist am Zug"; //Aktueller Spieler wird angezeigt
                if (this.gameStoryEnabled)
                    lblPlayer.Text = "Duellant ist am Zug"; //Aktueller Spieler wird angezeigt
            }
            else
            {
                lblPlayer.Text = "Kreuz ist am Zug"; //Aktueller Spieler wird angezeigt
            }
        }//Ende von buttonClick();

        private void computerMakeMove() //AI Algorithmus
        {
            //Priorität 1:  Gewinnen
            //Priorität 2:  Den Gegner am Gewinnen hindern
            //Priorität 3:  Ein Zeichen neben einer bereits vom Gegner gewählten Ecke setzten (um eine bestimme Gewinnstrategie zu verhindern)
            //Priorität 4:  Ein freies Feld finden

            int aiAuswahl = 0; //Variable die den von der AI ausgewählten Button darstellt

            aiAuswahl = gewinnenOderBlocken(2); //Möglichst Gewinnen indem nach eigenen Feldern gesucht wird
            if (aiAuswahl == 0)
            {
                aiAuswahl = gewinnenOderBlocken(1); //Möglichst den Gegner am Gewinnen hindern indem nach gegnerischen Feldern gesucht wird
                if (aiAuswahl == 0)
                {
                    aiAuswahl = eckeBlockieren(); //Eine
                    if (aiAuswahl == 0)
                    {
                        aiAuswahl = freiesFeldSuchen();
                    }
                }
            }
            buttonClick(aiAuswahl); //Den von der AI ausgewählten Button drücken
        }
        private int gewinnenOderBlocken(int playerID)
        {
            Console.WriteLine("Sucht nach Gewinn- // Block- moeglichkeit:  " + playerID);
            //Horizontale Tests
            //Reihe 1
            if ((this.A1 == playerID) && (this.A2 == playerID) && (this.A3 == 0))
                return 3;
            if ((this.A2 == playerID) && (this.A3 == playerID) && (this.A1 == 0))
                return 1;
            if ((this.A1 == playerID) && (this.A3 == playerID) && (this.A2 == 0))
                return 2;
            //Reihe 2
            if ((this.B1 == playerID) && (this.B2 == playerID) && (this.B3 == 0))
                return 6;
            if ((this.B2 == playerID) && (this.B3 == playerID) && (this.B1 == 0))
                return 4;
            if ((this.B1 == playerID) && (this.B3 == playerID) && (this.B2 == 0))
                return 5;
            //Reihe 3
            if ((this.C1 == playerID) && (this.C2 == playerID) && (this.C3 == 0))
                return 9;
            if ((this.C2 == playerID) && (this.C3 == playerID) && (this.C1 == 0))
                return 7;
            if ((this.C1 == playerID) && (this.C3 == playerID) && (this.C2 == 0))
                return 8;

            //Vertikale Tests
            //Spalte 1
            if ((this.A1 == playerID) && (this.B1 == playerID) && (this.C1 == 0))
                return 7;
            if ((this.B1 == playerID) && (this.C1 == playerID) && (this.A1 == 0))
                return 1;
            if ((this.A1 == playerID) && (this.C1 == playerID) && (this.B1 == 0))
                return 4;
            //Spalte 2
            if ((this.A2 == playerID) && (this.B2 == playerID) && (this.C2 == 0))
                return 8;
            if ((this.B2 == playerID) && (this.C2 == playerID) && (this.A2 == 0))
                return 2;
            if ((this.A2 == playerID) && (this.C2 == playerID) && (this.B2 == 0))
                return 5;
            //Spalte 3
            if ((this.A3 == playerID) && (this.B3 == playerID) && (this.C3 == 0))
                return 9;
            if ((this.B3 == playerID) && (this.C3 == playerID) && (this.A3 == 0))
                return 3;
            if ((this.A3 == playerID) && (this.C3 == playerID) && (this.B3 == 0))
                return 6;

            //Diagonale Tests
            //Oben links nach rechts unten
            if ((this.A1 == playerID) && (this.B2 == playerID) && (this.C3 == 0))
                return 9;
            if ((this.B2 == playerID) && (this.C3 == playerID) && (this.A1 == 0))
                return 1;
            if ((this.A1 == playerID) && (this.C3 == playerID) && (this.B2 == 0))
                return 5;
            //Unten links nach rechts oben
            if ((this.A3 == playerID) && (this.B2 == playerID) && (this.C1 == 0))
                return 7;
            if ((this.B2 == playerID) && (this.C1 == playerID) && (this.A3 == 0))
                return 3;
            if ((this.A3 == playerID) && (this.C1 == playerID) && (this.B2 == 0))
                return 5;
            return 0; //Wenn keine Möglichkeit gefunden wurde
        }//Ende von GewinnenOderBlocken

        private int eckeBlockieren() //Sucht eine Ecke zum Blockieren
        {
            Console.WriteLine("Sucht eine Ecke zum Blockieren");
            //Wenn oben links belegt ist
            if (this.A1 == 1)
            {
                if (this.A2 == 0)
                    return 2;
                if (this.B1 == 0)
                    return 4;
            }
            //Wenn oben rechts belegt ist
            if (A3 == 1)
            {
                if (this.B3 == 0)
                    return 6;
                if (this.A2 == 0)
                    return 2;
            }
            //Wenn unten rechts belegt ist
            if (this.C3 == 1)
            {
                if(this.C2 == 0)
                    return 8;
                if (this.B3 == 0)
                    return 6;
            }
            //Wenn unten links belegt ist
            if (this.C1 == 1)
            {
                if (this.B1 == 0)
                    return 4;
                if (this.C2 == 0)
                    return 8;
            }
            return 0; //Wenn jede Ecke belegt ist
        }

        private int freiesFeldSuchen() //Nach einem freien Feld suchen
        {
            Console.WriteLine("Sucht ein Freies Feld");
            if (this.B2 == 0)
                return 5;
            if (this.A1 == 0)
                return 1;
            if (this.A2 == 0)
                return 2;
            if (this.A3 == 0)
                return 3;
            if (this.B1 == 0)
                return 4;
            if (this.B3 == 0)
                return 6;
            if (this.C1 == 0)
                return 7;
            if (this.C2 == 0)
                return 8;
            if (this.C3 == 0)
                return 9;
            return 0; //Wenn kein freies Feld gefunden wurde
        }
        //Ende AI Algorithmus
    }//Ende der Klasse
}//Ende des Namespaces
