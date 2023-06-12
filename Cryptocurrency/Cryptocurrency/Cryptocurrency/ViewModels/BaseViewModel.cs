using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, IInitializeAsync, INavigationAware, IDestructible
    {
        // Реалізація методів інтерфейсів
        public virtual void Initialize(INavigationParameters parameters)
        {
            // Реалізація логіки ініціалізації
        }

        public virtual Task InitializeAsync(INavigationParameters parameters)
        {
            // Реалізація асинхронної логіки ініціалізації
            return Task.CompletedTask;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Реалізація логіки після переходу зі сторінки
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            // Реалізація логіки після переходу на сторінку
        }

        public virtual void Destroy()
        {
            // Реалізація логіки знищення об'єкта
        }
    }
}
