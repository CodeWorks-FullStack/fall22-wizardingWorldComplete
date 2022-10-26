-- Active: 1666715463005@@SG-butter-rabbit-3552-6842-mysql-master.servers.mongodirector.com@3306@garbagecollector

CREATE TABLE
    IF NOT EXISTS characters (
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL,
        age int NOT NULL CHECK(age > 0),
        isAlive bool NOT NULL,
        house VARCHAR(255),
        description VARCHAR(255),
        imgUrl VARCHAR(255),
        authorId VARCHAR(255) NOT NULL,
        FOREIGN KEY(authorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';