CREATE DATABASE  IF NOT EXISTS `appengsoftware` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `appengsoftware`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: appengsoftware
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `gravamensagem`
--

DROP TABLE IF EXISTS `gravamensagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gravamensagem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mensagem` varchar(200) NOT NULL,
  `idUsuario` varchar(45) DEFAULT NULL,
  `idSala` int(11) DEFAULT NULL,
  `sequenciaMensagem` int(11) DEFAULT NULL,
  `dataMensagem` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=254 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gravamensagem`
--

LOCK TABLES `gravamensagem` WRITE;
/*!40000 ALTER TABLE `gravamensagem` DISABLE KEYS */;
INSERT INTO `gravamensagem` VALUES (214,'xD\r\n','MARCOS',41,1,'2019-12-10 19:12:08'),(215,'ahha','MARCOS',41,2,'2019-12-10 21:10:47'),(216,'cfh','MARCOS',41,3,'2019-12-11 20:19:05'),(217,'xD','MARCOS',52,1,'2019-12-11 20:33:25'),(218,'asdasd','MARCOS',52,2,'2019-12-11 20:33:28'),(219,'sdfsfdsdf','MARCOS',52,3,'2019-12-11 20:33:31'),(220,'sdfsfdsdf','MARCOS',52,4,'2019-12-11 20:39:14'),(221,'xD','MARCOS',52,5,'2019-12-11 20:39:20'),(222,'dfsfdfsgdsg','MARCOS',52,6,'2019-12-11 20:39:27'),(223,'oloco man','MARCOS',52,7,'2019-12-11 20:39:33'),(224,'sdfsdf','MARCOS',52,8,'2019-12-11 20:39:41'),(225,'xD','MARCOS',54,1,'2019-12-11 20:40:00'),(226,'xD','MARCOS',54,2,'2019-12-11 20:40:05'),(227,'xD','MARCOS',54,3,'2019-12-11 20:42:16'),(228,'xD','MARCOS',54,4,'2019-12-11 20:42:24'),(229,'sdfasdfas','MARCOS',54,5,'2019-12-11 20:42:28'),(230,'sdfasdfadsf','MARCOS',54,6,'2019-12-11 20:42:32'),(231,'sdfsdfsdfsdfsaf','MARCOS',54,7,'2019-12-11 20:42:35'),(232,'sadfsdfasfdsdfsdf','MARCOS',54,8,'2019-12-11 20:42:40'),(233,'ADIOAHGUASDGUIADSFUAGIUOGIUOGIAGIUAGOUAGAGUIAGUOAG','MARCOS',54,9,'2019-12-11 20:42:46'),(234,'ADIOAHGUASDGUIADSFUAGIUOGIUOGIAGIUAGOUAGAGUIAGUOAG','MARCOS',54,10,'2019-12-11 20:43:05'),(235,'ADIOAHGUASDGUIADSFUAGIUOGIUOGIAGIUAGOUAGAGUIAGUOAG','MARCOS',54,11,'2019-12-11 20:44:36'),(236,'dfdfg','MARCOS',54,12,'2019-12-11 20:44:58'),(237,'tyytytytyyyy','MARCOS',54,13,'2019-12-11 20:45:06'),(238,'hhhh','MARCOS',43,1,'2019-12-11 20:45:24'),(239,'etyetyhety','MARCOS',43,2,'2019-12-11 20:45:28'),(240,'etyetyhety','MARCOS',43,3,'2019-12-11 20:45:46'),(241,'etyetyhety','MARCOS',43,4,'2019-12-11 20:46:02'),(242,'etyetyhety','MARCOS',43,5,'2019-12-11 20:46:23'),(243,'xD','MARCOS',43,6,'2019-12-11 20:46:32'),(244,'xD','MARCOS',51,1,'2019-12-11 20:46:43'),(245,'dfgdff','MARCOS',51,2,'2019-12-11 20:46:46'),(246,'olooooooooco','MARCOS',51,3,'2019-12-11 20:46:54'),(247,'sdfsdfsdfsdf','MARCOS',51,4,'2019-12-11 20:46:59'),(248,'casasdasd','MARCOS',51,5,'2019-12-11 20:47:06'),(249,'asasdadsa','MARCOS',51,6,'2019-12-11 20:47:11'),(250,'Eai galera, tudo bem com voces?','MARCOS',41,4,'2019-12-11 20:52:21'),(251,'opa, estou muito bem :)','HERON',41,5,'2019-12-11 20:52:51'),(252,'Vai rolar essa partidinha esse fim de semana em !','RENAN',41,6,'2019-12-11 20:53:37'),(253,'Espero vocês la','RENAN',41,7,'2019-12-11 20:53:50');
/*!40000 ALTER TABLE `gravamensagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sala`
--

DROP TABLE IF EXISTS `sala`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sala` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `senha` varchar(45) DEFAULT NULL,
  `qntJogadores` int(11) DEFAULT NULL,
  `local` varchar(100) DEFAULT NULL,
  `dataJogo` datetime DEFAULT NULL,
  `dataInicio` datetime DEFAULT NULL,
  `categoria` varchar(45) DEFAULT NULL,
  `descricao` varchar(100) DEFAULT NULL,
  `usuario` varchar(45) DEFAULT NULL,
  `image` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sala`
--

LOCK TABLES `sala` WRITE;
/*!40000 ALTER TABLE `sala` DISABLE KEYS */;
INSERT INTO `sala` VALUES (41,'Yu-gi-oh Online',NULL,5,'Dois Córregos','2019-12-04 00:00:00','2019-12-03 00:00:00',NULL,'Tá na hora do duelo!','renan','yugioh-legacy-duelist-box-art.jpg'),(42,'Jogar peteca',NULL,4,'Brotas','2019-12-03 00:00:00','2019-12-03 19:48:47','online','Jogar uma petequinha hoje depois da aula FATEC JAU','marcos','peteca-artesanal-colorida.jpg'),(43,'peteca',NULL,5,'Jau','2019-12-03 00:00:00','2019-12-03 20:45:59','Nonline','partida de peteca hoje','vanderley','download.jpg'),(51,'Jogar Basquete',NULL,5,'Jau','2019-12-22 00:00:00','2019-12-10 19:20:26','online','Partidinha de basquete','MARCOS','056452f400c1eb8b44a5f89e3a326140f.jpg'),(52,'Jogar uno',NULL,4,'Bauru','2019-12-20 00:00:00','2019-12-10 19:22:09',NULL,'Partidinha de uno legal','MARCOS','0uno1-3c494b95d67787ebcc15605069443718-640-0.jpg'),(53,'Futebol',NULL,5,'Brotas','2019-12-20 00:00:00','2019-12-10 19:27:53',NULL,'Partida de futebol','HERON','0mundial-de-futebol.jpg'),(54,'Xadrez',NULL,4,'Jau','2019-12-10 00:00:00','2019-12-10 20:24:14',NULL,'Jogar xadrez, local ainda nao definido','MARCOS','0373437688e5c2fa805.jpg');
/*!40000 ALTER TABLE `sala` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `senha` varchar(45) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `recebeNotificacao` tinyint(4) DEFAULT NULL,
  `ultimoLogin` datetime DEFAULT NULL,
  `idSala` varchar(45) DEFAULT NULL,
  `image` varchar(200) DEFAULT NULL,
  `sobre` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Marcos Junior',NULL,'mod.gluguer@gmail.com','14981448287',1,'2019-12-09 00:29:30',NULL,'16907052_388863201487250_5793352450656174080_n.jpg','O mais lindo do mundo <3'),(2,'Mirela',NULL,'mirela@hotmail.com','14981052033',1,'2019-12-09 13:09:18',NULL,'Jiraya-Naruto-to-Boruto-DLC-600x374-1280x720.jpg','Eu sou eu e nada mais'),(3,'leonardo','password',NULL,NULL,0,NULL,NULL,'sasuke1.jpg',NULL),(4,'heron','password',NULL,NULL,0,'2019-12-11 20:52:34',NULL,'pedroinst.png',NULL),(5,'renan','password',NULL,NULL,0,'2019-12-11 20:53:05',NULL,'kK6AiOT3_400x400.jpg',NULL),(6,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,NULL),(7,'Marcos Junior','40xeyxqnv','mod.gluguer@gmail.com','14981052033',1,'2019-12-09 00:31:25',NULL,'716907052_388863201487250_5793352450656174080_n.jpg','O mais lindo do mundo <3'),(8,'Marcos Junior','40xeyxqnv','mod.gluguer@gmail.com','14981052033',1,'2019-12-09 00:33:56',NULL,'816907052_388863201487250_5793352450656174080_n.jpg','O mais lindo do mundo <3'),(9,'Gluguer','jujuba22','marcos2@gmail.com','14981052033',1,NULL,NULL,NULL,NULL),(10,'joao','123456789','marcos2@gmail.com',NULL,1,NULL,NULL,NULL,NULL),(11,'joao','123456789','marcos2@gmail.com',NULL,1,NULL,NULL,NULL,NULL),(12,'Mirela','panela','mirela@hotmail.com',NULL,1,'2019-12-09 13:09:18',NULL,NULL,NULL),(13,'vanderley','password','vanderley@gmail.com','14981448487',1,'2019-12-03 20:43:12',NULL,NULL,NULL),(14,'joaozinho',NULL,'joaozinho@gmail.com','14981448487',0,'2019-12-08 23:03:16',NULL,'14Jiraya-Naruto-to-Boruto-DLC-600x374-1280x720.jpg',NULL),(15,'MARCOS',NULL,'mod.gluguer@gmail.com','14981448487',0,'2019-12-11 21:10:44',NULL,'16907052_388863201487250_5793352450656174080_n.jpg',NULL),(16,'marcos','40xeyxqnv','mod.gluguer@gmail.com','14981448487',0,'2019-12-11 21:10:44',NULL,'016907052_388863201487250_5793352450656174080_n.jpg',NULL);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios_sala`
--

DROP TABLE IF EXISTS `usuarios_sala`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios_sala` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeUsuario` varchar(45) DEFAULT NULL,
  `idSala` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios_sala`
--

LOCK TABLES `usuarios_sala` WRITE;
/*!40000 ALTER TABLE `usuarios_sala` DISABLE KEYS */;
INSERT INTO `usuarios_sala` VALUES (45,'heron','40'),(46,'marcos','40'),(47,'renan','40'),(48,'leonardo','40'),(49,'heron','39'),(50,'marcos','42'),(51,'marcos','38'),(52,'marcos','39'),(54,'renan','41'),(55,'heron','38'),(57,'vanderley','43'),(58,'heron','43'),(59,'marcos','43'),(60,'marcos','41'),(61,'marcos','44'),(62,'marcos','45'),(63,'marcos','46'),(64,'marcos','49'),(65,'marcos','50'),(67,'joaozinho','50'),(68,'mirela','50'),(69,'Marcos Junior','50'),(70,'Mirela','39'),(71,'MARCOS','51'),(72,'MARCOS','52'),(73,'HERON','53'),(74,'MARCOS','53'),(75,'MARCOS','54'),(76,'HERON','41'),(77,'RENAN','52');
/*!40000 ALTER TABLE `usuarios_sala` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visualizamensagem`
--

DROP TABLE IF EXISTS `visualizamensagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visualizamensagem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idUsuario` int(11) NOT NULL,
  `idSala` int(11) NOT NULL,
  `sequenciaMensagem` int(11) NOT NULL,
  `dataVisualizado` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visualizamensagem`
--

LOCK TABLES `visualizamensagem` WRITE;
/*!40000 ALTER TABLE `visualizamensagem` DISABLE KEYS */;
/*!40000 ALTER TABLE `visualizamensagem` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-11 22:40:48
