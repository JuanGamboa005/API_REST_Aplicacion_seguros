-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `idcliente` int NOT NULL AUTO_INCREMENT,
  `cc` varchar(45) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `edad` int NOT NULL,
  `foto` varchar(100) NOT NULL,
  `telefono` varchar(45) NOT NULL,
  PRIMARY KEY (`idcliente`),
  UNIQUE KEY `idcliente_UNIQUE` (`idcliente`),
  UNIQUE KEY `cc_UNIQUE` (`cc`),
  UNIQUE KEY `foto_UNIQUE` (`foto`),
  UNIQUE KEY `telefono_UNIQUE` (`telefono`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'1014659511','Juan Gamboa',18,'https//:photo0001','3160450422'),(2,'2068213742','Maria Lopez',25,'https://photo0002','3171122334'),(3,'3095820163','Pedro Rodriguez',30,'https://photo0003','3156677885'),(4,'4147392654','Ana Martinez',40,'https://photo0004','3144455667'),(5,'5201456785','Luis Sanchez',22,'https://photo0005','3189988776'),(6,'6312987436','Laura Perez',35,'https://photo0006','3112233445'),(7,'7436548917','Carlos Gomez',45,'https://photo0007','3101234567'),(8,'8589012368','Isabel Torres',28,'https://photo0008','3178765432'),(9,'9694675829','Miguel Rivera',50,'https://photo0009','3195554446'),(10,'1075634920','Sofia Herrera',33,'https://photo0010','3161122334');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleado` (
  `idempleado` int NOT NULL AUTO_INCREMENT,
  `cc` int NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `edad` int NOT NULL,
  `foto` varchar(100) NOT NULL,
  `telefono` varchar(45) NOT NULL,
  PRIMARY KEY (`idempleado`),
  UNIQUE KEY `idempleado_UNIQUE` (`idempleado`),
  UNIQUE KEY `cc_UNIQUE` (`cc`),
  UNIQUE KEY `foto_UNIQUE` (`foto`),
  UNIQUE KEY `telefono_UNIQUE` (`telefono`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,1180123451,'Javier Ramirez',55,'https://photo0011','3177778886'),(2,1297845632,'Carmen Rojas',23,'https://photo0012','3128889997'),(3,1302987653,'Diego Gonzalez',38,'https://photo0013','3145556668'),(4,1412654314,'Elena Castro',48,'https://photo0014','3109999887'),(5,1524876955,'Andres Ortiz',20,'https://photo0015','3191234567'),(6,1632948706,'Natalia Vargas',42,'https://photo0016','3139876543'),(7,1745678237,'Roberto Jimenez',58,'https://photo0017','3167890123'),(8,1854321678,'Marta Silva',26,'https://photo0018','3123456789'),(9,1965432899,'Hector Perez',52,'https://photo0019','3146543210'),(10,2079654320,'Ana Maria Fernandez',32,'https://photo0020','3192345678');
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `idproductos` int NOT NULL AUTO_INCREMENT,
  `detalle` varchar(100) NOT NULL,
  PRIMARY KEY (`idproductos`),
  UNIQUE KEY `idproductos_UNIQUE` (`idproductos`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'seguroVida'),(2,'seguroEducativo'),(3,'seguroAccidentes');
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venta` (
  `idventa` int NOT NULL AUTO_INCREMENT,
  `cliente_idcliente` int NOT NULL,
  `empleado_idempleado` int NOT NULL,
  `productos_idproductos` int NOT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFin` datetime NOT NULL,
  PRIMARY KEY (`idventa`),
  UNIQUE KEY `idventa_UNIQUE` (`idventa`),
  KEY `fk_venta_cliente_idx` (`cliente_idcliente`),
  KEY `fk_venta_empleado1_idx` (`empleado_idempleado`),
  KEY `fk_venta_productos1_idx` (`productos_idproductos`),
  CONSTRAINT `fk_venta_cliente` FOREIGN KEY (`cliente_idcliente`) REFERENCES `cliente` (`idcliente`),
  CONSTRAINT `fk_venta_empleado1` FOREIGN KEY (`empleado_idempleado`) REFERENCES `empleado` (`idempleado`),
  CONSTRAINT `fk_venta_productos1` FOREIGN KEY (`productos_idproductos`) REFERENCES `productos` (`idproductos`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` VALUES (1,1,1,3,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(2,1,1,3,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(3,2,2,3,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(4,2,2,1,'2023-09-08 14:30:45','2032-09-08 14:30:45'),(5,3,3,3,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(6,3,3,2,'2023-09-08 14:30:45','2030-09-08 14:30:45'),(7,4,4,3,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(8,4,4,1,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(9,5,5,3,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(10,5,5,2,'2023-09-08 14:30:45','2033-09-08 14:30:45'),(11,6,6,3,'2023-09-08 14:30:45','2030-09-08 14:30:45'),(12,6,6,1,'2023-09-08 14:30:45','2030-09-08 14:30:45'),(13,7,6,3,'2023-09-08 14:30:45','2031-09-08 14:30:45'),(14,8,6,3,'2023-09-08 14:30:45','2032-09-08 14:30:45'),(15,9,8,3,'2023-09-08 14:30:45','2028-09-08 14:30:45'),(16,10,8,3,'2023-09-08 14:30:45','2030-09-08 14:30:45');
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-09-09  9:24:03
