using Caliburn.Micro;
using PropertyChanged;
using System.ComponentModel.Composition;
using System;

namespace Publisher.ViewModels
{
    /// <summary>
    /// Subscriber ViewModel
    /// </summary>
    [ImplementPropertyChanged]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export]
    public class SubscriberViewModel : IHandle<EventContent>
    {
        /// <summary>
        /// get, set PublishContent
        /// </summary>
        public string PublishContent { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SubscriberViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);
        }

        /// <summary>
        /// Handle when recive event
        /// </summary>
        /// <param name="message">the event content message</param>
        public void Handle(EventContent message)
        {
            PublishContent = message.Message;
        }
    }
}
