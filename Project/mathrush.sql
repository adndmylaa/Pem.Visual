CREATE DATABASE mathrush;

USE mathrush;

CREATE TABLE scores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100),
    score INT,
    played_at DATETIME DEFAULT CURRENT_TIMESTAMP
)

CREATE TABLE leaderboard (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50),
    score INT
);

;
