
-- MySQL Workbench Synchronization
-- Generated: 2018-02-23 13:55
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: admin

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `playyourcvdatabase` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`Usuarios` (
  `idUsuario` INT(11) NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NULL DEFAULT NULL,
  `Apellido1` VARCHAR(45) NULL DEFAULT NULL,
  `Apellido2` VARCHAR(45) NULL DEFAULT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `contrasenya` VARCHAR(45) NOT NULL,
  `Telefono` VARCHAR(12) NULL DEFAULT NULL,
  `FechaNacimiento` DATE NULL DEFAULT NULL,
  `MostrarMascota` TINYINT(1) NULL DEFAULT NULL,
  `fotoURL` VARCHAR(500) NULL DEFAULT NULL,
  `Usuariocol` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idUsuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`CV` (
  `idCV` INT(11) NOT NULL AUTO_INCREMENT,
  `Titulo` VARCHAR(45) NULL DEFAULT NULL,
  `URL` VARCHAR(150) NULL DEFAULT NULL,
  `Usuario_idUsuario` INT(11) NOT NULL,
  PRIMARY KEY (`idCV`),
  INDEX `fk_CV_Usuario_idx` (`Usuario_idUsuario` ASC),
  CONSTRAINT `fk_CV_Usuario`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `playyourcvdatabase`.`Usuarios` (`idUsuario`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`Categorias` (
  `idCategorias` INT(11) NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NULL DEFAULT NULL,
  `Experiencia` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idCategorias`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`Contenidos` (
  `idContenido` INT(11) NOT NULL AUTO_INCREMENT,
  `idUsuario` INT(11) NOT NULL,
  `Categorias_idCategorias` INT(11) NOT NULL,
  `Nombre` VARCHAR(45) NULL DEFAULT NULL,
  `Descripcion` VARCHAR(420) NULL DEFAULT NULL,
  `Empresa_Escuela` VARCHAR(45) NULL DEFAULT NULL,
  `Lugar` VARCHAR(45) NULL DEFAULT NULL,
  `Posicion` VARCHAR(45) NULL DEFAULT NULL,
  `FechaInicio` DATE NULL DEFAULT NULL,
  `FechaFin` DATE NULL DEFAULT NULL,
  `Hablado` VARCHAR(45) NULL DEFAULT NULL,
  `Escrito` VARCHAR(45) NULL DEFAULT NULL,
  `Leido` VARCHAR(45) NULL DEFAULT NULL,
  `NivelGeneral` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idContenido`),
  INDEX `fk_Contenido_Categorias1_idx` (`Categorias_idCategorias` ASC),
  INDEX `fk_Usuario_idx` (`idUsuario` ASC),
  CONSTRAINT `fk_Contenido_Categorias1`
    FOREIGN KEY (`Categorias_idCategorias`)
    REFERENCES `playyourcvdatabase`.`Categorias` (`idCategorias`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Usuario`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `playyourcvdatabase`.`Usuarios` (`idUsuario`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`Objetivos` (
  `idObjetivos` INT(11) NOT NULL AUTO_INCREMENT,
  `Primaria` TINYINT(1) NULL DEFAULT NULL,
  `Descripcion` VARCHAR(140) NULL DEFAULT NULL,
  `Objetivos_idObjetivos` INT(11) NULL DEFAULT NULL,
  `Usuario_idUsuario` INT(11) NOT NULL,
  `Categorias_idCategorias` INT(11) NOT NULL,
  PRIMARY KEY (`idObjetivos`),
  INDEX `fk_Objetivos_Objetivos1_idx` (`Objetivos_idObjetivos` ASC),
  INDEX `fk_Objetivos_Usuario1_idx` (`Usuario_idUsuario` ASC),
  INDEX `fk_Objetivos_Categorias1_idx` (`Categorias_idCategorias` ASC),
  CONSTRAINT `fk_Objetivos_Objetivos1`
    FOREIGN KEY (`Objetivos_idObjetivos`)
    REFERENCES `playyourcvdatabase`.`Objetivos` (`idObjetivos`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Objetivos_Usuario1`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `playyourcvdatabase`.`Usuarios` (`idUsuario`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Objetivos_Categorias1`
    FOREIGN KEY (`Categorias_idCategorias`)
    REFERENCES `playyourcvdatabase`.`Categorias` (`idCategorias`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`Logros` (
  `idLogros` INT(11) NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NULL DEFAULT NULL,
  `DescripcionSpanish` VARCHAR(45) NULL DEFAULT NULL,
  `TotalNecesario` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idLogros`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`CV_has_Categorias` (
  `CV_idCV` INT(11) NOT NULL,
  `Categorias_idCategorias` INT(11) NOT NULL,
  PRIMARY KEY (`CV_idCV`, `Categorias_idCategorias`),
  INDEX `fk_CV_has_Categorias_Categorias1_idx` (`Categorias_idCategorias` ASC),
  INDEX `fk_CV_has_Categorias_CV1_idx` (`CV_idCV` ASC),
  CONSTRAINT `fk_CV_has_Categorias_CV1`
    FOREIGN KEY (`CV_idCV`)
    REFERENCES `playyourcvdatabase`.`CV` (`idCV`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_CV_has_Categorias_Categorias1`
    FOREIGN KEY (`Categorias_idCategorias`)
    REFERENCES `playyourcvdatabase`.`Categorias` (`idCategorias`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`CV_has_not_Contenido` (
  `CV_idCV` INT(11) NOT NULL,
  `Contenido_idContenido` INT(11) NOT NULL,
  `Contenido_Categorias_idCategorias` INT(11) NOT NULL,
  PRIMARY KEY (`CV_idCV`, `Contenido_idContenido`, `Contenido_Categorias_idCategorias`),
  INDEX `fk_CV_has_Contenido_Contenido1_idx` (`Contenido_idContenido` ASC, `Contenido_Categorias_idCategorias` ASC),
  INDEX `fk_CV_has_Contenido_CV1_idx` (`CV_idCV` ASC),
  CONSTRAINT `fk_CV_has_Contenido_CV1`
    FOREIGN KEY (`CV_idCV`)
    REFERENCES `playyourcvdatabase`.`CV` (`idCV`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_CV_has_Contenido_Contenido1`
    FOREIGN KEY (`Contenido_idContenido`)
    REFERENCES `playyourcvdatabase`.`Contenidos` (`idContenido`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`Usuario_has_Logros` (
  `Logros_idLogros` INT(11) NOT NULL,
  `Usuario_idUsuario` INT(11) NOT NULL,
  `Contador` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`Logros_idLogros`, `Usuario_idUsuario`),
  INDEX `fk_Logros_has_Usuario_Usuario1_idx` (`Usuario_idUsuario` ASC),
  INDEX `fk_Logros_has_Usuario_Logros1_idx` (`Logros_idLogros` ASC),
  CONSTRAINT `fk_Logros_has_Usuario_Logros1`
    FOREIGN KEY (`Logros_idLogros`)
    REFERENCES `playyourcvdatabase`.`Logros` (`idLogros`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Logros_has_Usuario_Usuario1`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `playyourcvdatabase`.`Usuarios` (`idUsuario`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`DialogosMascota` (
  `idDialogosMascota` INT(11) NOT NULL AUTO_INCREMENT,
  `ContenidoSpanish` VARCHAR(280) NULL DEFAULT NULL,
  PRIMARY KEY (`idDialogosMascota`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `playyourcvdatabase`.`PreguntasObjetivo` (
  `idPreguntasObjetivo` INT(11) NOT NULL AUTO_INCREMENT,
  `ContenidoSpanish` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idPreguntasObjetivo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;