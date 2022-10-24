CREATE SCHEMA accounts_test_db;

-- CREATE TABLES
CREATE TABLE table_roles (
    role_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE table_accounts (
    account_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    login VARCHAR(75) NOT NULL UNIQUE,
    password VARCHAR(20) NOT NULL,
    is_delete BOOL NOT NULL DEFAULT FALSE,
    role_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES table_roles(role_id) 
        ON UPDATE NO ACTION 
        ON DELETE NO ACTION 
);

CREATE TABLE table_users(
    user_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(125) NOT NULL ,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(125) NOT NULL,
    tel VARCHAR(20) NULL,
    FOREIGN KEY (user_id) REFERENCES table_accounts(account_id) 
        ON UPDATE NO ACTION 
        ON DELETE NO ACTION 
);

-- CREATE FUNCTIONS
DELIMITER |
CREATE FUNCTION function_get_role_id_by_name(role_name VARCHAR(50)) 
    RETURNS INT DETERMINISTIC
BEGIN 
    DECLARE id INT;
    
    SET @exist_id := EXISTS(SELECT role_id FROM table_roles WHERE name = role_name);
    IF @exist_id THEN
        SELECT role_id INTO id FROM table_roles WHERE name = role_name;
    ELSE
        SELECT role_id INTO id FROM table_roles WHERE name = 'guest';
    END IF;
    
    RETURN id;
END |


-- CREATE PROCEDURES
DELIMITER |
CREATE PROCEDURE procedure_insert_account_user(IN _login VARCHAR(75), IN _password VARCHAR(20), 
                                                IN _role_name VARCHAR(50), 
                                                IN _first_name VARCHAR(125), IN _last_name VARCHAR(255),
                                                IN _email VARCHAR(125), IN _tel VARCHAR(20))
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
        BEGIN
            ROLLBACK;
        END;
    
    DECLARE EXIT HANDLER FOR SQLWARNING 
        BEGIN 
           ROLLBACK;
        END;
    
    START TRANSACTION;
        INSERT INTO table_accounts(login, password, role_id)
            VALUES (_login, _password, function_get_role_id_by_name(_role_name));
        INSERT INTO table_users(first_name, last_name, email, tel)
            VALUES (_first_name, _last_name, _email, _tel);
    COMMIT;
END |

-- INSERT FAKE DATA
INSERT INTO table_roles (name) 
VALUES ('admin'),
       ('user'),
       ('guest');

CALL procedure_insert_account_user('admin', '12345', 'admin', 'Admin', 'Administrator', 'admin@ya.ru', '+7(123)1231212');
CALL procedure_insert_account_user('anst', '123', 'user', 'Andrey', 'Starinin', 'starinin-andrey@ya.ru', '+7(904)2144491');
CALL procedure_insert_account_user('anonim', '0000', 'anonim', 'Anonim', 'Anonimus', 'anonim@ya.ru', '+7(123)1231212');
