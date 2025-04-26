using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private NavigationService _navigation;

        public string Title { get; set; }
        public Bitmap? Image { get; set; }
        public HomeViewModel()
        {
            Title = "Дисциплинарная практика";
            var filePath = Path.Combine(AppContext.BaseDirectory, "logo.png");
            if (File.Exists(filePath))
            {
                Image = new Bitmap(filePath);
            }
            else
            {
                Image = null;
            }
        }

        public HomeViewModel(NavigationService navigation) : this()
        {
            _navigation = navigation;
        }

        [RelayCommand]
        public void OpenServicemanList()
        {
            _navigation.NavigateTo<ServicemanListViewModel>();
        }
    }
}
