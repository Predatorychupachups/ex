using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp4.Commands;
using WpfApp4.ViewModel;

namespace WpfApp4.ViewModel
{
    internal class Window1ViewModel : BaseViewModel
    {
        private List<Item> _dataGridItems;
        public List<Item> DataGridItems
        {
            get => _dataGridItems;
            set => SetPropertyChanged(ref _dataGridItems, value);
        }
        
        public Window1ViewModel()
        {
            using (var context = new PostavshikRuEntities())
            {
                DataGridItems = context.Item.ToList();
            }
        }

        //public ICommand EditButton
        //{
        //    get;
        //    private set;
        //}

        //public Window1ViewModel()
        //{
        //    EditButton = new RelayCommand(EditGrid);
        //}
            
        //public void EditGrid(object a)
        //{
            
        //}

    }
}
