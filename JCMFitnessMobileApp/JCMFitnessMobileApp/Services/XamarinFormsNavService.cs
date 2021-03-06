using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JCMFitnessMobileApp.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;


//[assembly: Dependency(typeof(XamarinFormsNavService))]
namespace JCMFitnessMobileApp.Services
{
    public class XamarinFormsNavService : INavService
    {

        readonly IDictionary<Type, Type> _map =
            new Dictionary<Type, Type>();
        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _map.Add(viewModel, view);
        }

        public INavigation XamarinFormsNav { get; set; }

        public event PropertyChangedEventHandler CanGoBackChanged;

        public bool CanGoBack =>
            XamarinFormsNav.NavigationStack != null
            && XamarinFormsNav.NavigationStack.Count > 0;
        public async Task GoBack()
        {
            if (CanGoBack)
            {
                await XamarinFormsNav.PopAsync(true);
                OnCanGoBackChanged();
            }
        }
        public async Task NavigateTo<TVM>()
            where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));
            if (XamarinFormsNav.NavigationStack.Last().BindingContext is BaseViewModel)
            {
                ((BaseViewModel)XamarinFormsNav.NavigationStack.Last().BindingContext).Init();
            }
        }
        public async Task NavigateTo<TVM, TParameter>(TParameter parameter)
            where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));
            if (XamarinFormsNav.NavigationStack.Last().BindingContext is BaseViewModel<TParameter>)
            {
                ((BaseViewModel<TParameter>)XamarinFormsNav.NavigationStack.Last().BindingContext).Init(parameter);
            }
        }
        public void RemoveLastView()
        {
            
            var lastView = XamarinFormsNav.NavigationStack[XamarinFormsNav.NavigationStack.Count - 2];
            XamarinFormsNav.RemovePage(lastView);
        }
        public void RemoveLastTwoViews()
        {
            if (XamarinFormsNav.NavigationStack.Count < 1)
            {
                return;
            }
            var lastView = XamarinFormsNav.NavigationStack[XamarinFormsNav.NavigationStack.Count - 1];
            var lastView1 = XamarinFormsNav.NavigationStack[XamarinFormsNav.NavigationStack.Count - 2];
            XamarinFormsNav.RemovePage(lastView);
            XamarinFormsNav.RemovePage(lastView1);
        }

        public void ClearBackStack()
        {
            if (XamarinFormsNav.NavigationStack.Count < 2)
            {
                return;
            }
            for (var i = 0; XamarinFormsNav.NavigationStack.Count > 1;)
            {
                var page = XamarinFormsNav.NavigationStack[i];
                XamarinFormsNav.RemovePage(page);
            }
        }
        public void NavigateToUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Invalid URI");
            }
            Launcher.OpenAsync(uri);
        }
        async Task NavigateToView(Type viewModelType)
        {
            if (!_map.TryGetValue(viewModelType, out Type viewType))
            {
                throw new ArgumentException("No view found in view mapping for " + viewModelType.FullName + ".");
            }
            // Use reflection to get the View's constructor and create an instance of the View
            var constructor = viewType.GetTypeInfo()
                                      .DeclaredConstructors
                                      .FirstOrDefault(dc => !dc.GetParameters().Any());
            var view = constructor.Invoke(null) as Page;
            var vm = ((App)Application.Current)
                .Kernel
                .GetService(viewModelType);

            view.BindingContext = vm;
            await XamarinFormsNav.PushAsync(view, true);
        }
        void OnCanGoBackChanged() => CanGoBackChanged?.Invoke(this, new PropertyChangedEventArgs("CanGoBack"));


        // TODO: INavService implementation goes here.
    }

}