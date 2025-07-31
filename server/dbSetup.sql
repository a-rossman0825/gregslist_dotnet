CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
  ) DEFAULT charset utf8mb4 COMMENT '';

CREATE TABLE
  cars (
    -- id should always be your first column
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    make VARCHAR(50) NOT NULL,
    model VARCHAR(100) NOT NULL,
    `year` SMALLINT UNSIGNED NOT NULL,
    price MEDIUMINT UNSIGNED NOT NULL,
    img_url VARCHAR(500) NOT NULL,
    description VARCHAR(500),
    engine_type ENUM ('V6', 'V8', 'V10', '4-cylinder', 'unknown') NOT NULL,
    color VARCHAR(50) NOT NULL,
    mileage MEDIUMINT UNSIGNED NOT NULL,
    has_clean_title BOOLEAN DEFAULT TRUE NOT NULL,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
  );

DROP TABLE cars;

INSERT INTO
  cars (
    make,
    model,
    `year`,
    price,
    img_url,
    description,
    engine_type,
    color,
    mileage,
    has_clean_title,
    creator_id
  )
VALUES
  (
    'vw',
    'golf',
    1980,
    40000,
    'https://images.unsplash.com/photo-1751528962027-ac9f0370ff5d?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxmZWF0dXJlZC1waG90b3MtZmVlZHw0fHx8ZW58MHx8fHx8',
    'guacomobile',
    'V8',
    'avocado',
    100000,
    FALSE,
    '65f87bc1e02f1ee243874743'
  );

SELECT
  *
FROM
  cars;

SELECT
  *
FROM
  cars;

SELECT
  *
FROM
  accounts;

SELECT
  cars.*,
  accounts.*
FROM
  cars
  JOIN accounts ON cars.creator_id = accounts.id
ORDER BY
  cars.created_at ASC;

SELECT
  cars.*,
  accounts.*
FROM
  cars
  JOIN accounts ON cars.creator_id = accounts.id
WHERE
  cars.id = 1;

SELECT
  cars.*,
  accounts.*
FROM
  cars
  JOIN accounts ON cars.creator_id = accounts.id
WHERE
  cars.id = 2;

UPDATE cars
SET
  color = 'green'
WHERE
  id = 3;


  CREATE TABLE houses(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  sqft MEDIUMINT UNSIGNED NOT NULL,
  bedrooms TINYINT UNSIGNED NOT NULL,
  bathrooms DOUBLE(3, 1) UNSIGNED NOT NULL,
  img_url VARCHAR(500) NOT NULL,
  description VARCHAR(500),
  price MEDIUMINT UNSIGNED NOT NULL,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
);

DROP TABLE houses;

INSERT INTO
  houses (
    sqft,
    bedrooms,
    bathrooms,
    img_url,
    description,
    price,
    creator_id
  )
VALUES
  (
    800,
    2,
    1.5,
    'https://images.unsplash.com/photo-1668015642451-a3bb11afb441?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dGlueSUyMGhvbWV8ZW58MHx8MHx8fDA%3D',
    'tiny house',
    100000,
    '686d8ef556e974abecfe6d67'
  );

  DELETE FROM houses
  WHERE id = 1
  LIMIT 1;