using System;
using System.Collections.Generic;

namespace ApplicationLogics.AutosysServer
{

    public class RequestHandler
    {
        private readonly Queue<Request> _requestQueue;

        public RequestHandler()
        {
            _requestQueue = new Queue<Request>();
        }

        public bool IsRequestValid()
        {
            throw new NotImplementedException();
        }

        public void AddRequest(Request request)
        {
            _requestQueue.Enqueue(request);
            throw new NotImplementedException();
        }

        public IEnumerable<Request> GetRequests()
        {
            while (true)
            {
                if (_requestQueue.Count > 0)
                {
                    throw new NotImplementedException();
                }

            }
        }



    }
}