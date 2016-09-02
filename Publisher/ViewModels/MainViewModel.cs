using Caliburn.Micro;
using PropertyChanged;
using System.ComponentModel.Composition;

namespace Publisher.ViewModels
{
    /// <summary>
    /// Main View Model
    /// </summary>
    [Export(typeof(IShell))]
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        /// <summary>
        /// get, set PublishContent
        /// </summary>
        public string PublishContent { get; set; }

        /// <summary>
        /// Publish Event content action
        /// </summary>
        public void PublishEvent()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread(new EventContent() { Message = PublishContent });
        }

        /// <summary>
        /// Show a Window that subcribe EventContent
        /// </summary>
        public void SubscribeEvent()
        {
            IoC.Get<IWindowManager>().ShowWindow(IoC.Get<SubscriberViewModel>());
        }
    }
}
