-- Active: 1666715463005@@SG-butter-rabbit-3552-6842-mysql-master.servers.mongodirector.com@3306@garbagecollector
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture',
  coverImg MEDIUMTEXT COMMENT 'User Cover Image'
) default charset utf8 COMMENT '';
