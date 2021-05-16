using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using X_O_v_2.Control;
using X_O_v_2.View.ViewModel;


namespace X_O_v_2.ModelView
{
    public class ViewModel :  INotifyPropertyChanged
    {
        private bool state = true;
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                if (state)
                    Player = "X";
                else
                    Player = "0";
                OnPropertyChanged("Player");
            }
        }

        private string player = "X";
        public string Player
        {
            get { return player; }
            set { player = value; }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; // ивент обновления
        public void OnPropertyChanged([CallerMemberName] string prop = "")
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        #endregion
        private RelayCommand chek_rezult;     
        public RelayCommand ChekRezult
        {
            get
            {
                return chek_rezult ?? (chek_rezult = new RelayCommand(act =>
                {
                    List<Cell> cells = new List<Cell>();
                    foreach (var item in (act as UIElementCollection))
                    {
                        if (item is Cell)
                            cells.Add(item as Cell);
                    }

                    #region горизонталь Х
                    if (cells[0].btn.Content == "X" && cells[1].btn.Content == "X" && cells[2].btn.Content == "X" ||
                    cells[3].btn.Content == "X" && cells[4].btn.Content == "X" && cells[5].btn.Content == "X" ||
                    cells[6].btn.Content == "X" && cells[7].btn.Content == "X" && cells[8].btn.Content == "X")
                    {
                        MessageBox.Show("X WIN", "Game Over",MessageBoxButton.OK);
                        Block(act);
                        return;
                    }
                    #endregion
                    #region вертикаль Х
                    else if (cells[0].btn.Content == "X" && cells[3].btn.Content == "X" && cells[6].btn.Content == "X" ||
                    cells[1].btn.Content == "X" && cells[4].btn.Content == "X" && cells[7].btn.Content == "X" ||
                     cells[2].btn.Content == "X" && cells[5].btn.Content == "X" && cells[8].btn.Content == "X")
                    {
                        MessageBox.Show("X WIN", "Game Over");
                        Block(act);
                        return;
                    }
                    #endregion
                    #region диагональ Х
                    else if (cells[0].btn.Content == "X" && cells[4].btn.Content == "X" && cells[8].btn.Content == "X" ||
                    cells[2].btn.Content == "X" && cells[4].btn.Content == "X" && cells[6].btn.Content == "X")
                    {
                        MessageBox.Show("X WIN", "Game Over");
                        Block(act);
                        return;
                    }
                    #endregion
                    #region горизонталь 0
                    else if (cells[0].btn.Content == "0" && cells[1].btn.Content == "0" && cells[2].btn.Content == "0" ||
                    cells[3].btn.Content == "0" && cells[4].btn.Content == "0" && cells[5].btn.Content == "0" ||
                    cells[6].btn.Content == "0" && cells[7].btn.Content == "0" && cells[8].btn.Content == "0")
                    {
                        MessageBox.Show("0 WIN", "Game Over");
                        Block(act);
                        return;
                    }
                    #endregion
                    #region вертикаль 0
                    else if (cells[0].btn.Content == "0" && cells[3].btn.Content == "0" && cells[6].btn.Content == "0" ||
                    cells[1].btn.Content == "0" && cells[4].btn.Content == "0" && cells[7].btn.Content == "0" ||
                    cells[2].btn.Content == "0" && cells[5].btn.Content == "0" && cells[8].btn.Content == "0")
                    {
                        MessageBox.Show("0 WIN", "Game Over");
                        Block(act);
                        return;
                    }
                    #endregion
                    #region диагональ 0
                    else if (cells[0].btn.Content == "0" && cells[4].btn.Content == "0" && cells[8].btn.Content == "0" ||
                    cells[2].btn.Content == "0" && cells[4].btn.Content == "0" && cells[6].btn.Content == "0")
                    {
                        MessageBox.Show("0 WIN", "Game Over");
                        Block(act);
                        return;
                    }
                    #endregion
                    else if(cells.FindAll(i=> i.btn.Content != ""&& i.btn.Content != null).Count==9)
                    {
                        MessageBox.Show("Ничия", "Game Over");                      
                        return;
                    }
                }));
            }
        }
        internal void Click(Button act)
        {
            if (State)
                act.Content = "X";
            else
                act.Content = "0";
            act.IsEnabled = false;
            var t = State ? false : true;
            State = t;           
        }
        private void Block(object act)
        {
            foreach (var item in (act as UIElementCollection))
            {
                if (item is Cell)
                    (item as Cell).btn.IsEnabled = false;
            }
        }
    }
}
