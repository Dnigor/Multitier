using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using ApplicationServer;
using System.Threading;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        #region SeuUp
        private IPEndPoint endPoint;
        private Socket desktopSocket;
        DesktopClient.JsonProtocol protocol;

        [TestInitialize]
        public void Setup()
        {
            endPoint = new IPEndPoint(IPAddress.Any, 8008);
            desktopSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            protocol = new DesktopClient.JsonProtocol();
        }
        #endregion

        #region Server
        [TestMethod]
        public void ServerTest()
        {
            Server server = new Server(new Listener(new IPEndPoint(IPAddress.Any, 8888)), new ClientsManager());
            server.Start();
            Thread.Sleep(1000);
            server.Stop();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ServerWrongPort()
        {
            Server server = new Server(new Listener(new IPEndPoint(IPAddress.Any, -1)), new ClientsManager());
        }
        #endregion

        #region Listener

        #endregion

        #region ClientManager

        #endregion

        #region Custom
        private List<object> GetPerson()
        {
            Random random = new Random();
            int id = random.Next();
            byte[] photo = new byte[12];
            return new List<object>() 
            {
                id, 
                "FName" + id,
                "LName" + id,
                DateTime.Now,
                photo,
                "photo.jpg",
                "Email" + id,
                "+380" + id,
                "Description" + id,
                photo
            };
        }
        #endregion
    }
}
