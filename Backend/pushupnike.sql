-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-12-2023 a las 12:41:42
-- Versión del servidor: 10.4.27-MariaDB
-- Versión de PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `pushupnike`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE `categorias` (
  `id` varchar(50) NOT NULL,
  `nombre` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `categorias`
--

INSERT INTO `categorias` (`id`, `nombre`) VALUES
('abrigos', 'Abrigos'),
('camisetas', 'Camisetas'),
('pantalones', 'Pantalones');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id` varchar(50) NOT NULL,
  `titulo` varchar(255) NOT NULL,
  `imagen` varchar(255) NOT NULL,
  `categoria_id` varchar(50) NOT NULL,
  `precio` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id`, `titulo`, `imagen`, `categoria_id`, `precio`) VALUES
('abrigo-01', 'Abrigo 01', './img/abrigos/01.jpg', 'abrigos', '1000.00'),
('abrigo-02', 'Abrigo 02', './img/abrigos/02.jpg', 'abrigos', '1000.00'),
('abrigo-03', 'Abrigo 03', './img/abrigos/03.jpg', 'abrigos', '1000.00'),
('abrigo-04', 'Abrigo 04', './img/abrigos/04.jpg', 'abrigos', '1000.00'),
('abrigo-05', 'Abrigo 05', './img/abrigos/05.jpg', 'abrigos', '1000.00'),
('camiseta-01', 'Camiseta 01', './img/camisetas/01.jpg', 'camisetas', '1000.00'),
('camiseta-02', 'Camiseta 02', './img/camisetas/02.jpg', 'camisetas', '1000.00'),
('camiseta-03', 'Camiseta 03', './img/camisetas/03.jpg', 'camisetas', '1000.00'),
('camiseta-04', 'Camiseta 04', './img/camisetas/04.jpg', 'camisetas', '1000.00'),
('camiseta-05', 'Camiseta 05', './img/camisetas/05.jpg', 'camisetas', '1000.00'),
('camiseta-06', 'Camiseta 06', './img/camisetas/06.jpg', 'camisetas', '1000.00'),
('camiseta-07', 'Camiseta 07', './img/camisetas/07.jpg', 'camisetas', '1000.00'),
('camiseta-08', 'Camiseta 08', './img/camisetas/08.jpg', 'camisetas', '1000.00'),
('pantalon-01', 'Pantalón 01', './img/pantalones/01.jpg', 'pantalones', '1000.00'),
('pantalon-02', 'Pantalón 02', './img/pantalones/02.jpg', 'pantalones', '1000.00'),
('pantalon-03', 'Pantalón 03', './img/pantalones/03.jpg', 'pantalones', '1000.00'),
('pantalon-04', 'Pantalón 04', './img/pantalones/04.jpg', 'pantalones', '1000.00'),
('pantalon-05', 'Pantalón 05', './img/pantalones/05.jpg', 'pantalones', '1000.00');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categorias`
--
ALTER TABLE `categorias`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `categoria_id` (`categoria_id`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `productos`
--
ALTER TABLE `productos`
  ADD CONSTRAINT `productos_ibfk_1` FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
