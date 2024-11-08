CREATE DATABASE  IF NOT EXISTS `acoemprendedores` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `acoemprendedores`;
-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: acoemprendedores
-- ------------------------------------------------------
-- Server version	8.0.26

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
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `IdCliente` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Apellido` varchar(50) NOT NULL,
  `DUI` char(10) NOT NULL,
  `TipoProducto` enum('CuentaAhorro','CuentaCorriente','TarjetaDebito','TarjetaCredito','PrestamoPersonal','PrestamoAgropecuario','PrestamoHipotecario') NOT NULL,
  `BilleteraVirtual` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`IdCliente`),
  UNIQUE KEY `DUI` (`DUI`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'Juan','Martin','91828929-2','CuentaAhorro',0.00),(3,'Miguel','Garmedia','02939381-1','CuentaAhorro',0.00),(5,'Pedro','Martinez','02939381-4','CuentaAhorro',0.00),(7,'Vanessa ','Reyes','92930291-2','CuentaCorriente',0.00);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleados` (
  `IdEmpleado` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Apellido` varchar(50) NOT NULL,
  `DUI` char(10) NOT NULL,
  `Rol` enum('Cajero','Asesor','AtencionCliente','Gerente') NOT NULL,
  PRIMARY KEY (`IdEmpleado`),
  UNIQUE KEY `DUI` (`DUI`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleados`
--

LOCK TABLES `empleados` WRITE;
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` VALUES (1,'Vladirmir ','Martinez','99292812-9','Cajero'),(2,'Gabriel','Villeda','18829233-1','Asesor'),(3,'Melissa','Castro','98388239-2','AtencionCliente'),(4,'Lucas','Acosta','01938381-1','Cajero'),(5,'Betsabe','Chavarria','92839212-1','Asesor'),(6,'Rafael','Reyes ','15227722-2','Gerente'),(7,'Mercesdez','Sanchez','12394567-3','Cajero'),(8,'Carina','Cortez','93893021-5','AtencionCliente'),(10,'Emanuel','Cordova','92829323-1','Cajero'),(11,'Daniela','Guardado','92839291-4','AtencionCliente');
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transacciones`
--

DROP TABLE IF EXISTS `transacciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transacciones` (
  `IdTransaccion` int NOT NULL AUTO_INCREMENT,
  `IdCliente` int NOT NULL,
  `IdEmpleado` int DEFAULT NULL,
  `FechaTransaccion` datetime DEFAULT CURRENT_TIMESTAMP,
  `TipoTransaccion` enum('Abono','Cargo') NOT NULL,
  `Monto` decimal(10,2) NOT NULL,
  `Descripcion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdTransaccion`),
  KEY `IdCliente` (`IdCliente`),
  KEY `IdEmpleado` (`IdEmpleado`),
  CONSTRAINT `transacciones_ibfk_1` FOREIGN KEY (`IdCliente`) REFERENCES `clientes` (`IdCliente`),
  CONSTRAINT `transacciones_ibfk_2` FOREIGN KEY (`IdEmpleado`) REFERENCES `empleados` (`IdEmpleado`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transacciones`
--

LOCK TABLES `transacciones` WRITE;
/*!40000 ALTER TABLE `transacciones` DISABLE KEYS */;
INSERT INTO `transacciones` VALUES (1,7,10,'2024-11-07 18:01:20','Abono',100.00,'Lorem');
/*!40000 ALTER TABLE `transacciones` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-07 19:42:14
