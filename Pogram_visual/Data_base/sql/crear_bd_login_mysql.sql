-- Script para recrear la base de datos MySQL usada por la app (bd_login)
-- ADVERTENCIA: ejecuta DROP DATABASE, se perderán datos existentes

DROP DATABASE IF EXISTS bd_login;
CREATE DATABASE bd_login CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE bd_login;

CREATE TABLE tb_login (
  id INT AUTO_INCREMENT PRIMARY KEY,
  usuario VARCHAR(100) NOT NULL UNIQUE,
  clave VARCHAR(255) NOT NULL
);

-- Usuario de ejemplo (contraseña en texto plano para pruebas)
INSERT INTO tb_login (usuario, clave) VALUES ('admin','1234');

-- Recomendación: almacenar hashes (bcrypt) en producción en lugar de contraseñas en texto plano.
