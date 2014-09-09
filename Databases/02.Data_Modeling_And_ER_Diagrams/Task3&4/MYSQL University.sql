-- MySQL Script generated by MySQL Workbench
-- 08/21/14 21:30:15
-- Model: New Model    Version: 1.0
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema task2
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `task2` ;
CREATE SCHEMA IF NOT EXISTS `task2` DEFAULT CHARACTER SET utf8 ;
USE `task2` ;

-- -----------------------------------------------------
-- Table `task2`.`faculties`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`faculties` ;

CREATE TABLE IF NOT EXISTS `task2`.`faculties` (
  `FacultyID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`FacultyID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `task2`.`departments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`departments` ;

CREATE TABLE IF NOT EXISTS `task2`.`departments` (
  `DepartmentID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `FacultyID` INT(11) NOT NULL,
  PRIMARY KEY (`DepartmentID`),
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `task2`.`faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `FK_Departments_Faculties` ON `task2`.`departments` (`FacultyID` ASC);


-- -----------------------------------------------------
-- Table `task2`.`professors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`professors` ;

CREATE TABLE IF NOT EXISTS `task2`.`professors` (
  `ProfessorID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `DepartmentID` INT(11) NOT NULL,
  PRIMARY KEY (`ProfessorID`),
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `task2`.`departments` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `FK_Professors_Departments` ON `task2`.`professors` (`DepartmentID` ASC);


-- -----------------------------------------------------
-- Table `task2`.`courses`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`courses` ;

CREATE TABLE IF NOT EXISTS `task2`.`courses` (
  `CourseID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `ProfessorID` INT(11) NOT NULL,
  PRIMARY KEY (`CourseID`),
  CONSTRAINT `FK_Courses_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `task2`.`professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `FK_Courses_Professors` ON `task2`.`courses` (`ProfessorID` ASC);


-- -----------------------------------------------------
-- Table `task2`.`students`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`students` ;

CREATE TABLE IF NOT EXISTS `task2`.`students` (
  `StudentID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `FacultyID` INT(11) NOT NULL,
  PRIMARY KEY (`StudentID`),
  CONSTRAINT `FK_Students_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `task2`.`faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `FK_Students_Faculties` ON `task2`.`students` (`FacultyID` ASC);


-- -----------------------------------------------------
-- Table `task2`.`coursesstudents`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`coursesstudents` ;

CREATE TABLE IF NOT EXISTS `task2`.`coursesstudents` (
  `CourseID` INT(11) NOT NULL,
  `StudentID` INT(11) NOT NULL,
  PRIMARY KEY (`CourseID`, `StudentID`),
  CONSTRAINT `FK_CoursesStudents_Courses`
    FOREIGN KEY (`StudentID`)
    REFERENCES `task2`.`courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_CoursesStudents_Students`
    FOREIGN KEY (`StudentID`)
    REFERENCES `task2`.`students` (`StudentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `FK_CoursesStudents_Courses` ON `task2`.`coursesstudents` (`StudentID` ASC);


-- -----------------------------------------------------
-- Table `task2`.`titles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`titles` ;

CREATE TABLE IF NOT EXISTS `task2`.`titles` (
  `TitleID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`TitleID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `task2`.`professorstitles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`professorstitles` ;

CREATE TABLE IF NOT EXISTS `task2`.`professorstitles` (
  `ProfessorID` INT(11) NOT NULL,
  `TitleID` INT(11) NOT NULL,
  PRIMARY KEY (`ProfessorID`, `TitleID`),
  CONSTRAINT `FK_ProfessorsTitles_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `task2`.`professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProfessorsTitles_Titles`
    FOREIGN KEY (`TitleID`)
    REFERENCES `task2`.`titles` (`TitleID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `FK_ProfessorsTitles_Titles` ON `task2`.`professorstitles` (`TitleID` ASC);


-- -----------------------------------------------------
-- Table `task2`.`sysdiagrams`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `task2`.`sysdiagrams` ;

CREATE TABLE IF NOT EXISTS `task2`.`sysdiagrams` (
  `name` VARCHAR(160) NOT NULL,
  `principal_id` INT(11) NOT NULL,
  `diagram_id` INT(11) NOT NULL AUTO_INCREMENT,
  `version` INT(11) NULL DEFAULT NULL,
  `definition` LONGBLOB NULL DEFAULT NULL,
  PRIMARY KEY (`diagram_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UK_principal_name` ON `task2`.`sysdiagrams` (`principal_id` ASC, `name` ASC);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
