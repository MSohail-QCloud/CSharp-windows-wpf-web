/*
SQLyog Ultimate v8.63 
MySQL - 5.6.21 : Database - dbmenumantap
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`dbmenumantap` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `dbmenumantap`;

/*Table structure for table `mnu_parent` */

DROP TABLE IF EXISTS `mnu_parent`;

CREATE TABLE `mnu_parent` (
  `MAINMNU` varchar(30) DEFAULT NULL,
  `STATUS` varchar(1) DEFAULT NULL,
  `MENUPARVAL` int(10) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`MENUPARVAL`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `mnu_parent` */

insert  into `mnu_parent`(`MAINMNU`,`STATUS`,`MENUPARVAL`) values ('Transactions','Y',1),('Inventory','Y',2),('Test','Y',3),('New1','Y',4),('Exit','Y',5);

/*Table structure for table `mnu_submenu` */

DROP TABLE IF EXISTS `mnu_submenu`;

CREATE TABLE `mnu_submenu` (
  `MENUPARVAL` int(10) DEFAULT NULL,
  `FRM_CODE` varchar(50) DEFAULT NULL,
  `FRM_NAME` varchar(50) DEFAULT NULL,
  `STATUS` varchar(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mnu_submenu` */

insert  into `mnu_submenu`(`MENUPARVAL`,`FRM_CODE`,`FRM_NAME`,`STATUS`) values (1,'FrmAccount','Accounting','Y'),(1,'FrmFinance','Finance','Y'),(3,'Test','Test','Y'),(5,'Login','Exit','Y'),(1,'ManageUser','Manage User','Y');

/*Table structure for table `mnu_userrole` */

DROP TABLE IF EXISTS `mnu_userrole`;

CREATE TABLE `mnu_userrole` (
  `ID` int(10) DEFAULT NULL,
  `UID` int(10) DEFAULT NULL,
  `FRM_CODE` varchar(50) DEFAULT NULL,
  `STATUS` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mnu_userrole` */

insert  into `mnu_userrole`(`ID`,`UID`,`FRM_CODE`,`STATUS`) values (1,1001,'FrmAccount',1),(2,1001,'FrmFinance',1),(3,1001,'test',1),(4,1001,'Login',1),(5,1001,'ManageUser',1),(NULL,1002,'FrmAccount',1),(NULL,1002,'FrmFinance',1),(NULL,1002,'Test',0),(NULL,1002,'Login',1),(NULL,1002,'ManageUser',1);

/*Table structure for table `tbl_user` */

DROP TABLE IF EXISTS `tbl_user`;

CREATE TABLE `tbl_user` (
  `UID` int(10) DEFAULT NULL,
  `UserName` varchar(30) DEFAULT NULL,
  `Position` varchar(30) DEFAULT NULL,
  `Password` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_user` */

insert  into `tbl_user`(`UID`,`UserName`,`Position`,`Password`) values (1001,'admin','sysadmin','a'),(1002,'jeo','User','a'),(1003,'a','a','a');

/*Table structure for table `vw_pagerole` */

DROP TABLE IF EXISTS `vw_pagerole`;

/*!50001 DROP VIEW IF EXISTS `vw_pagerole` */;
/*!50001 DROP TABLE IF EXISTS `vw_pagerole` */;

/*!50001 CREATE TABLE  `vw_pagerole`(
 `MENUPARVAL` int(10) ,
 `FRM_NAME` varchar(50) ,
 `FRM_CODE` varchar(50) ,
 `UID` int(10) ,
 `STATUS` bigint(11) 
)*/;

/*View structure for view vw_pagerole */

/*!50001 DROP TABLE IF EXISTS `vw_pagerole` */;
/*!50001 DROP VIEW IF EXISTS `vw_pagerole` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_pagerole` AS (select `s`.`MENUPARVAL` AS `MENUPARVAL`,`s`.`FRM_NAME` AS `FRM_NAME`,`s`.`FRM_CODE` AS `FRM_CODE`,`u`.`UID` AS `UID`,ifnull(`u`.`STATUS`,0) AS `STATUS` from (`mnu_submenu` `s` left join `mnu_userrole` `u` on((`s`.`FRM_CODE` = `u`.`FRM_CODE`)))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
