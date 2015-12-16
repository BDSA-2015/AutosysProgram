// ProtocolHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.StorageAdapter.Interface;
using Storage.Models;

namespace ApplicationLogics.ProtocolManagement
{
    /// <summary>
    ///     This class is responsible for handling incoming research protocols.
    /// </summary>
    public class ProtocolHandler
    {
        private IAdapter<Protocol, StoredProtocol> _adapter;

        public ProtocolHandler(IAdapter<Protocol, StoredProtocol> adapter)
        {
            _adapter = adapter;
        }

        public static void CreateProtocol()
        {
        }

        public static void ReadProtocol(Protocol protocol)
        {
        }

        public static void UpdateProtocol(Protocol protocol)
        {
        }

        public static void DeleteProtocol(int protocolId)
        {
        }
    }
}