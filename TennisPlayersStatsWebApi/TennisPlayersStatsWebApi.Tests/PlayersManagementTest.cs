using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisPlayersStatsWebApi.Controllers;
using System.IO;
using TennisPlayersWebApi.Models;

namespace TennisPlayersStatsWebApi.Tests
{
    /// <summary>
    /// Description résumée pour PlayersManagementTest
    /// </summary>
    [TestClass]
    public class PlayersManagementTest
    {
        public PlayersManagementTest()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAllPlayersFileNotFoundTest()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead_notfound.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playerslist = playerMgt.GetAllPlayers(filePath);
            Assert.AreEqual(null, playerslist);
        }

        [TestMethod]
        public void GetAllPlayersEmptyFileTest()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead_empty.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playerslist = playerMgt.GetAllPlayers(filePath);
            Assert.AreEqual(null, playerslist);
        }

        [TestMethod]
        public void GetAllPlayersFileCorruptedTest()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead_corrupted.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playerslist = playerMgt.GetAllPlayers(filePath);
            Assert.AreEqual(null, playerslist);
        }

        [TestMethod]
        public void GetAllPlayersFileOKTest()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playerslist = playerMgt.GetAllPlayers(filePath);
            Assert.AreEqual(5, playerslist.Count);
        }

        [TestMethod]
        public void GetExistantPlayerByIdTest()
        {
            int id = 17;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playersList = playerMgt.GetAllPlayers(filePath);
            Player existantPlayer = playerMgt.GetPlayerById(playersList, id);
            Assert.AreNotEqual(null, existantPlayer);
        }

        [TestMethod]
        public void GetNotExistantPlayerByIdTest()
        {
            int id = 1;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playersList = playerMgt.GetAllPlayers(filePath);
            Player existantPlayer = playerMgt.GetPlayerById(playersList, id);
            Assert.AreEqual(null, existantPlayer);
        }

        [TestMethod]
        public void DeleteExistantPlayerByIdTest()
        {
            int id = 17;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playersList = playerMgt.GetAllPlayers(filePath);
            Player deletedPlayer = playerMgt.DeletePlayerById(playersList, id);
            Assert.AreEqual(17, deletedPlayer.id);
            Assert.AreEqual(4, playersList.Count);
        }

        [TestMethod]
        public void DeleteNotExistantPlayerByIdTest()
        {
            int id = 1;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/headtohead.json");
            PlayersManagement playerMgt = new PlayersManagement();
            List<Player> playersList = playerMgt.GetAllPlayers(filePath);
            Player deletedPlayer = playerMgt.DeletePlayerById(playersList, id);
            Assert.AreEqual(null, deletedPlayer);
            Assert.AreEqual(5, playersList.Count);
        }
    }
}
