-- MySQL dump 10.13  Distrib 5.6.24, for Win32 (x86)
--
-- Host: localhost    Database: alumni
-- ------------------------------------------------------
-- Server version	5.7.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `vsbt`
--

DROP TABLE IF EXISTS `vsbt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vsbt` (
  `Stud` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Fname` varchar(45) NOT NULL DEFAULT '',
  `Sex` varchar(45) NOT NULL DEFAULT '',
  `Stat` varchar(45) NOT NULL DEFAULT '',
  `Bday` varchar(45) NOT NULL DEFAULT '',
  `Tribe` varchar(45) NOT NULL DEFAULT '',
  `TA` varchar(45) NOT NULL DEFAULT '',
  `Religion` varchar(45) NOT NULL DEFAULT '',
  `Num` varchar(45) NOT NULL DEFAULT '',
  `Yearg` varchar(45) NOT NULL DEFAULT '',
  `HomeA` varchar(45) NOT NULL DEFAULT '',
  `City` varchar(45) NOT NULL DEFAULT '',
  `Age` varchar(45) NOT NULL DEFAULT '',
  `EA` varchar(45) NOT NULL DEFAULT '',
  `Email` varchar(45) NOT NULL DEFAULT '',
  `Phase` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`Stud`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vsbt`
--

LOCK TABLES `vsbt` WRITE;
/*!40000 ALTER TABLE `vsbt` DISABLE KEYS */;
INSERT INTO `vsbt` VALUES (1,'Adlaon, Clemente Jr. C.','Male','','Monday, December 8, 1997','Bol-Anon','EIM','Filipinista','09101141515','2021','Purok Dalandan','Singaw Kidapawan','23','1st year High School ','','1'),(3,'Alojado, Christian Paul T.','Male','Single','Tuesday, January 6, 2004','Bisaya','SMAW','Catholic','09509744456','2021','Allab','Arakan Cotabato','17','Grade 10 Highschool','','1'),(7,'Bayawanon, Elmer Kem M.','Male','','Saturday, August 8, 1998','Manobo','ADM','COC','09653814422','2021','Datu Celo','Magpet','22','Grade 11 High School','','1'),(8,'ADSASDGSAB','Female','Married','Friday, March 11, 2022','','','','','2021','asdbfsbsvav','Magpet','54','','','2'),(9,'Dehino, Marcelo M.','Male','Single','Friday, March 21, 2003','Manobo','ADM','COC','09517889211','2019','Datu Celo','Magpet Cotabato','17','Grade 11 High School','','1'),(11,'asasgsdg','Male','','Monday, March 14, 2022','','','','','','','magpet','23','','','2'),(12,'dehno','Female','','Wednesday, March 16, 2022','bisaya','','','','2021','','magpet','','','','2'),(13,'lebron','Male','','Wednesday, March 16, 2022','','','','','','','magpet','','','','');
/*!40000 ALTER TABLE `vsbt` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-22  9:40:49
