using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCMFitnessMobileApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.ComponentModel;

namespace JCMFitnessMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWorkoutPage : ContentPage
    {
        NewWorkoutViewModel ViewModel =>
        BindingContext as NewWorkoutViewModel;
        public NewWorkoutPage()
        {
            InitializeComponent();
            BindingContextChanged += Page_BindingContextChanged;


            void Page_BindingContextChanged(object sender, EventArgs e)
            {
                ViewModel.ErrorsChanged += ViewModel_ErrorsChanged;
            }
            void ViewModel_ErrorsChanged(object sender,
                DataErrorsChangedEventArgs e)
            {
                var propHasErrors = (ViewModel.GetErrors(e.PropertyName)
                    as List<string>)?.Any() == true;
                switch (e.PropertyName)
                {
                    case nameof(ViewModel.Name):
                        if(propHasErrors)
                        {
                            name.TextColor = Color.Red;


                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}