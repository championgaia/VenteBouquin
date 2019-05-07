using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvvm.ViewModels
{
    public class MainViewModel 
    {
        public MainViewModel()
        {
            Message = "Message from View Model";
        }

        public string Message { get; set; }

    }
}
