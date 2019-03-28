using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RAT_Client;

namespace TTT
{
    static class TTTmain
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Client());

            using (var TTTstart = new TTTstart()) //Hier wird eine neue Instanz der TTTstart Klasse erzeugt
            {
                TTTstart.ShowDialog(); //Die Dialogbox der TTTstart Klasse wird angezeigt
                if (!TTTstart.returnExitGame)
                    Application.Run(new TTTgame(TTTstart.returnIsSingleplayer, TTTstart.returnStory)); //TTTgame wird mit den gegebenen Parametern von TTTstart aufgerufen
            }
            new Client().Show();
        }
    }
}
