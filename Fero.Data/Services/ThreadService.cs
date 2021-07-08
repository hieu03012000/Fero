using AutoMapper;
using Fero.Data.Repositories;
using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface IThreadService
    {
        Task ThreadInCasting(string modelId);
        int EndThread();
        Task CheckCasting(string modelId);
    }
    public partial class ThreadService : IThreadService
    {
        ICastingRepository _castingRepository;
        IMapper _mapper;
        Thread thread;
        public ThreadService(ICastingRepository castingRepository, IMapper mapper) 
        {
            _castingRepository = castingRepository;
            _mapper = mapper;
        }

        public async Task ThreadInCasting(string modelId)
        {
            thread = new Thread( async () => await CheckCasting(modelId));
            thread.Start();
        }

        public int EndThread()  
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Thread.CurrentThread.Abort();
            return 0;
        }

        public async Task CheckCasting(string modelId)
        {
            while (true)
            {
                DateTime currentDateTime = DateTime.Now;
                var incoming = _castingRepository
                    .Get(c => c.CloseTime < currentDateTime.AddDays(1) && c.CloseTime > currentDateTime)
                    .Select(c => c.Id).ToList();
                if(incoming != null && incoming.Count() != 0)
                {
                    var topic = modelId;
                    string listId = "";
                    foreach (var casting in incoming)
                    {
                        listId += casting.ToString() + ","; 
                    }
                    // See documentation on defining a message payload.
                    var message = new Message()
                    {
                        Notification = new Notification 
                        { 
                            Title = "You have a message", 
                            Body = "Some casting will close tomorrow" 
                        },
                        Data = new Dictionary<string, string>()
                        {
                            { "castingId", listId },
                        },
                        Topic = topic,
                    };

                    // Send a message to the devices subscribed to the provided topic.
                    string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                }
                Thread.Sleep(12 * 60 * 60 * 1000);
            }
        }
    }
}
