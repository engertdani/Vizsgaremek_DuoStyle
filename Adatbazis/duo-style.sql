-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Ápr 19. 12:54
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `duo-style`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `addresses`
--

CREATE TABLE `addresses` (
  `address_id` int(11) NOT NULL,
  `city` varchar(100) NOT NULL,
  `zip_code` varchar(20) NOT NULL,
  `street` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `appointments`
--

CREATE TABLE `appointments` (
  `appointment_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `service_id` int(11) NOT NULL,
  `note` varchar(100) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `appointment_date` date NOT NULL,
  `start_time` time NOT NULL,
  `finish_time` time DEFAULT NULL,
  `active` int(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `coupons`
--

CREATE TABLE `coupons` (
  `coupon_code` varchar(50) NOT NULL,
  `discount_amount` int(2) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `employees`
--

CREATE TABLE `employees` (
  `employee_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `tel` varchar(12) NOT NULL,
  `password` varchar(255) NOT NULL,
  `gender` varchar(1) NOT NULL,
  `join_date` date NOT NULL,
  `description` text NOT NULL,
  `fav_brand` varchar(100) NOT NULL,
  `img` varchar(100) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT 1,
  `admin` tinyint(1) NOT NULL,
  `salon_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `employees`
--

INSERT INTO `employees` (`employee_id`, `name`, `email`, `tel`, `password`, `gender`, `join_date`, `description`, `fav_brand`, `img`, `active`, `admin`, `salon_id`) VALUES
(1, 'Engert Dániel', 'danielengert06@gmail.com', '+36301234567', '123456', 'f', '2026-03-05', 'Tapasztalt, precíz barber és szalonvezető', 'Uppercut', 'engertdaniel.png', 1, 1, 1),
(2, 'Szabó Zsanett', '[zsanett@salon.hu](mailto:zsanett@salon.hu)', '+36301234568', '123456', 'n', '2026-03-05', 'Precíz barber, modern fade és szakáll specialistája', 'Reuzel', 'szabozsanett.png', 1, 0, 1),
(3, 'Kis Ádám', '[adam@salon.hu](mailto:adam@salon.hu)', '+36301234569', '123456', 'f', '2026-03-05', 'Fiatal barber, modern férfi hajstílusok szakértője', 'American Crew', 'kisadam.png', 1, 0, 1),
(4, 'Chamie Mohamed', '[mohamed@massage.hu](mailto:mohamed@massage.hu)', '+36301234570', '123456', 'f', '2026-03-05', 'Profi masszőr, relax és sportmasszázs specialista', 'Weleda', 'chamiemohamed.png', 1, 0, 2),
(5, 'Szabó Máté', '[mate@massage.hu](mailto:mate@massage.hu)', '+36301234571', '123456', 'f', '2026-03-05', 'Gyógy és relax masszázs specialista', 'Yamuna', 'szabomate.png', 1, 0, 2),
(6, 'Csiha Fanni', '[fanni@massage.hu](mailto:fanni@massage.hu)', '+36301234572', '123456', 'n', '2026-03-05', 'Relaxációs és aromaterápiás masszőr', 'AromaLand', 'csihafanni.png', 1, 0, 2),

--
-- Eseményindítók `employees`
--
DELIMITER $$
CREATE TRIGGER `update_appointments_on_employee_inactive` AFTER UPDATE ON `employees` FOR EACH ROW BEGIN
    IF NEW.active = 0 AND OLD.active != 0 THEN        
        UPDATE appointments
        SET active = 0
        WHERE employee_id = OLD.employee_id;
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `evaluations`
--

CREATE TABLE `evaluations` (
  `evaluation_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `evaluation_date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `evaluation_text` text NOT NULL,
  `star` tinyint(1) NOT NULL,
  `public` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `order`
--

CREATE TABLE `order` (
  `order_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `address_id` int(11) NOT NULL,
  `tel` varchar(12) DEFAULT NULL,
  `shipping_method` varchar(20) NOT NULL,
  `paying_method` varchar(20) NOT NULL,
  `coupon_code` varchar(50) DEFAULT NULL,
  `total_amount` decimal(10,2) NOT NULL,
  `note` varchar(100) DEFAULT NULL,
  `ordered_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `order_sent` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `order_products`
--

CREATE TABLE `order_products` (
  `order_products_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `variant_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `prices`
--

CREATE TABLE `prices` (
  `price_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `service_id` int(11) NOT NULL,
  `price` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `prices`
--

INSERT INTO `prices` (`price_id`, `employee_id`, `service_id`, `price`) VALUES
(1, 1, 1, 4000),
(2, 1, 2, 5500),
(3, 1, 3, 3000),
(4, 1, 4, 7000),
(5, 2, 1, 4200),
(6, 2, 2, 5700),
(7, 2, 3, 3200),
(8, 2, 4, 7200),
(9, 3, 1, 3900),
(10, 3, 2, 5400),
(11, 3, 3, 2800),
(12, 3, 4, 6800),
(13, 4, 5, 9000),
(14, 4, 6, 8500),
(15, 4, 7, 9200),
(16, 4, 8, 9500),
(17, 4, 9, 6000),
(18, 5, 5, 8800),
(19, 5, 6, 8300),
(20, 5, 7, 9100),
(21, 5, 8, 9400),
(22, 5, 9, 5800),
(23, 6, 5, 8700),
(24, 6, 6, 8200),
(25, 6, 7, 9000),
(26, 6, 8, 9300),
(27, 6, 9, 5700);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `products`
--

CREATE TABLE `products` (
  `pn` varchar(9) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` text NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `products`
--

INSERT INTO `products` (`pn`, `name`, `description`, `created_at`) VALUES
('FOD000001', 'Férfi matt hajpomádé', 'Matt hatású hajpomádé természetes megjelenéshez és erős, mégis rugalmas tartáshoz.', '2026-01-31 22:01:31'),
('FOD000002', 'Keratin regeneráló sampon', 'Keratin tartalmú sampon, amely segít helyreállítani a haj szerkezetét és erősíti a hajszálakat.', '2026-01-31 22:01:31'),
('FOD000003', 'Hidratáló hajbalzsam argánolajjal', 'Argánolajjal dúsított hajbalzsam a puha, könnyen kezelhető hajért.', '2026-01-31 22:01:31'),
('FOD000004', 'Intenzív hajpakolás száraz hajra', 'Mélyen tápláló hajpakolás, amely visszaadja a száraz haj rugalmasságát.', '2026-01-31 22:01:31'),
('FOD000005', 'Professzionális hajformázó krém', 'Könnyű állagú formázó krém természetes fényért és kontrollért.', '2026-01-31 22:01:31'),
('FOD000006', 'Selymes hajvégápoló szérum', 'Pipettás szérum a hajvégek ápolására és fényesítésére.', '2026-01-31 22:01:31'),
('FOD000007', 'Hővédő spray hajvasaláshoz', 'Hővédő permet, amely megóvja a hajat a hajformázás során fellépő hőkárosodástól.', '2026-01-31 22:01:31'),
('FOD000008', 'Extra erős tartású hajlakk', 'Hosszan tartó fixálást biztosító professzionális hajlakk.', '2026-01-31 22:01:31'),
('FOD000009', 'Tápláló hajolaj argán és kókusz olajjal', 'Természetes olajokkal dúsított hajolaj a fényes és egészséges hajért.', '2026-01-31 22:01:31'),
('FOD000010', 'Fejbőrápoló tonik', 'Frissítő és nyugtató fejbőrápoló tonik mindennapi használatra.', '2026-01-31 22:01:31'),
('MAS000001', 'Relaxáló masszázsolaj – Levendula', 'Prémium minőségű levendulás masszázsolaj, amely segíti az ellazulást és nyugtatja az izmokat.', '2026-01-31 22:02:09'),
('MAS000002', 'Aromaterápiás illóolaj – Eukaliptusz', 'Frissítő eukaliptusz illóolaj, ideális aromaterápiás és masszázs kezelésekhez.', '2026-01-31 22:02:09'),
('MAS000003', 'Masszázsgyertya – Olvadó olaj', 'Melegedő masszázsgyertya, amely olvadás után tápláló masszázsolajjá válik.', '2026-01-31 22:02:09'),
('MAS000004', 'Prémium masszázskrém', 'Gazdag állagú masszázskrém, hosszan tartó siklást biztosít.', '2026-01-31 22:02:09'),
('MAS000005', 'Forró köves masszázs kőszett', 'Bazalt kövekből álló masszázskő szett professzionális kezelésekhez.', '2026-01-31 22:02:09'),
('MAS000006', 'Gyógynövényes masszázsbatyu', 'Természetes gyógynövényekkel töltött masszázsbatyu relaxáló kezelésekhez.', '2026-01-31 22:02:09'),
('MAS000007', 'Izomlazító balzsam', 'Intenzív hatású balzsam fáradt és túlterhelt izmokra.', '2026-01-31 22:02:09'),
('MAS000008', 'Testradír tengeri sóval', 'Tengeri sós testradír az elhalt hámsejtek eltávolításához.', '2026-01-31 22:02:09'),
('MAS000009', 'Izomfrissítő gél', 'Gyors felszívódású gél sportolás és masszázs után.', '2026-01-31 22:02:09'),
('MAS000010', 'Relaxációs gyógytea', 'Gyógynövényes tea masszázs és kezelések után.', '2026-01-31 22:02:09');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `product_variant`
--

CREATE TABLE `product_variant` (
  `variant_id` int(11) NOT NULL,
  `pn` varchar(9) NOT NULL,
  `size` varchar(10) NOT NULL,
  `stock` int(11) NOT NULL DEFAULT 0,
  `price` int(11) NOT NULL,
  `active` tinyint(4) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `product_variant`
--

INSERT INTO `product_variant` (`variant_id`, `pn`, `size`, `stock`, `price`, `active`) VALUES
(1, 'FOD000001', '100g', 49, 2590, 1),
(2, 'FOD000002', '250ml', 58, 3190, 1),
(3, 'FOD000003', '250ml', 60, 2890, 1),
(4, 'FOD000004', '300ml', 34, 3390, 1),
(5, 'FOD000005', '150ml', 45, 2790, 1),
(6, 'FOD000006', '50ml', 50, 2990, 1),
(7, 'FOD000007', '200ml', 39, 2690, 1),
(8, 'FOD000008', '400ml', 30, 2590, 1),
(9, 'FOD000009', '100ml', 45, 3290, 1),
(10, 'FOD000010', '100ml', 50, 2490, 1),
(11, 'MAS000001', '250ml', 49, 3490, 1),
(12, 'MAS000002', '10ml', 40, 1990, 1),
(13, 'MAS000003', '150g', 29, 2990, 1),
(14, 'MAS000004', '500ml', 25, 3290, 1),
(15, 'MAS000005', '1 szett', 12, 8990, 1),
(16, 'MAS000006', '1 db', 19, 2790, 1),
(17, 'MAS000007', '100ml', 35, 2490, 1),
(18, 'MAS000008', '300g', 30, 2690, 1),
(19, 'MAS000009', '200ml', 40, 2890, 1),
(20, 'MAS000010', '20 filter', 50, 1590, 1),
(21, 'FOD000001', '200g', 48, 3000, 1),
(22, 'MAS000005', '2 szett', 30, 12500, 1),
(23, 'FOD000001', '300g', 4, 4290, 1),
(24, 'MAS000003', '200g', 50, 3999, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `salons`
--

CREATE TABLE `salons` (
  `salon_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `location` varchar(100) NOT NULL,
  `img` varchar(100) NOT NULL,
  `open_time` time NOT NULL,
  `close_time` time NOT NULL,
  `tel` varchar(12) NOT NULL,
  `email` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `salons`
--

INSERT INTO `salons` (`salon_id`, `name`, `location`, `img`, `open_time`, `close_time`, `tel`, `email`) VALUES
(1, 'DuoStyle Szalon - Barber', '2085 Pilisvörösvár, Fishteich utca 6.', 'salon_barber.png', '08:00:00', '20:00:00', '+36309551310', 'engert.daniel@verebelyszki.hu'),
(2, 'DuoStyle Szalon - Massage', '2030 Érd, Kőműves utca 43.', 'salon_massage.png', '09:00:00', '21:00:00', '+36703020370', 'chamie.mohamed@verebelyszki.hu');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `services`
--

CREATE TABLE `services` (
  `service_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `duration` int(11) NOT NULL,
  `active` tinyint(1) NOT NULL,
  `salon_id` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `services`
--

INSERT INTO `services` (`service_id`, `name`, `duration`, `active`, `salon_id`) VALUES
(1, 'Rövid hajvágás', 20, 1, 1),
(2, 'Hosszú hajvágás', 30, 1, 1),
(3, 'Szakálligazítás', 15, 1, 1),
(4, 'Hajvágás + Szakálligazítás', 60, 1, 1),
(5, 'Svéd masszázs', 60, 1, 2),
(6, 'Gyógymasszázs', 45, 1, 2),
(7, 'Sportmasszázs', 60, 1, 2),
(8, 'Relaxáló aromaterápiás masszázs', 75, 1, 2),
(9, 'Talpmasszázs', 30, 1, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `shifts`
--

CREATE TABLE `shifts` (
  `shift_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `shift_date` date NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `tel` varchar(12) NOT NULL,
  `password` varchar(255) NOT NULL,
  `born_date` date NOT NULL,
  `gender` varchar(1) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `verification_token` varchar(64) DEFAULT NULL,
  `verified_at` timestamp NULL DEFAULT NULL,
  `active` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `addresses`
--
ALTER TABLE `addresses`
  ADD PRIMARY KEY (`address_id`);

--
-- A tábla indexei `appointments`
--
ALTER TABLE `appointments`
  ADD PRIMARY KEY (`appointment_id`),
  ADD KEY `fk_appointments_employee` (`employee_id`),
  ADD KEY `fk_appointments_user` (`user_id`),
  ADD KEY `fk_appointments_service` (`service_id`);

--
-- A tábla indexei `coupons`
--
ALTER TABLE `coupons`
  ADD PRIMARY KEY (`coupon_code`);

--
-- A tábla indexei `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`employee_id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `fk_employees_salon` (`salon_id`);

--
-- A tábla indexei `evaluations`
--
ALTER TABLE `evaluations`
  ADD PRIMARY KEY (`evaluation_id`),
  ADD KEY `fk_evaluations_user` (`user_id`);

--
-- A tábla indexei `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `fk_order_user` (`user_id`),
  ADD KEY `fk_order_coupon` (`coupon_code`);

--
-- A tábla indexei `order_products`
--
ALTER TABLE `order_products`
  ADD PRIMARY KEY (`order_products_id`),
  ADD KEY `fk_order_products_order` (`order_id`),
  ADD KEY `fk_order_products_variant` (`variant_id`);

--
-- A tábla indexei `prices`
--
ALTER TABLE `prices`
  ADD PRIMARY KEY (`price_id`),
  ADD KEY `fk_prices_employee` (`employee_id`),
  ADD KEY `fk_prices_service` (`service_id`);

--
-- A tábla indexei `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`pn`);

--
-- A tábla indexei `product_variant`
--
ALTER TABLE `product_variant`
  ADD PRIMARY KEY (`variant_id`),
  ADD KEY `fk_product_variant_product` (`pn`);

--
-- A tábla indexei `salons`
--
ALTER TABLE `salons`
  ADD PRIMARY KEY (`salon_id`);

--
-- A tábla indexei `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`service_id`),
  ADD KEY `fk_services_salon` (`salon_id`);

--
-- A tábla indexei `shifts`
--
ALTER TABLE `shifts`
  ADD PRIMARY KEY (`shift_id`),
  ADD KEY `fk_shifts_employee` (`employee_id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `addresses`
--
ALTER TABLE `addresses`
  MODIFY `address_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `appointments`
--
ALTER TABLE `appointments`
  MODIFY `appointment_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `employees`
--
ALTER TABLE `employees`
  MODIFY `employee_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT a táblához `evaluations`
--
ALTER TABLE `evaluations`
  MODIFY `evaluation_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `order`
--
ALTER TABLE `order`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `order_products`
--
ALTER TABLE `order_products`
  MODIFY `order_products_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `prices`
--
ALTER TABLE `prices`
  MODIFY `price_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT a táblához `product_variant`
--
ALTER TABLE `product_variant`
  MODIFY `variant_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT a táblához `salons`
--
ALTER TABLE `salons`
  MODIFY `salon_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `services`
--
ALTER TABLE `services`
  MODIFY `service_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT a táblához `shifts`
--
ALTER TABLE `shifts`
  MODIFY `shift_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `appointments`
--
ALTER TABLE `appointments`
  ADD CONSTRAINT `fk_appointments_employee` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`employee_id`),
  ADD CONSTRAINT `fk_appointments_service` FOREIGN KEY (`service_id`) REFERENCES `services` (`service_id`),
  ADD CONSTRAINT `fk_appointments_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Megkötések a táblához `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `fk_employees_salon` FOREIGN KEY (`salon_id`) REFERENCES `salons` (`salon_id`);

--
-- Megkötések a táblához `evaluations`
--
ALTER TABLE `evaluations`
  ADD CONSTRAINT `fk_evaluations_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Megkötések a táblához `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `fk_order_coupon` FOREIGN KEY (`coupon_code`) REFERENCES `coupons` (`coupon_code`),
  ADD CONSTRAINT `fk_order_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Megkötések a táblához `order_products`
--
ALTER TABLE `order_products`
  ADD CONSTRAINT `fk_order_products_order` FOREIGN KEY (`order_id`) REFERENCES `order` (`order_id`),
  ADD CONSTRAINT `fk_order_products_variant` FOREIGN KEY (`variant_id`) REFERENCES `product_variant` (`variant_id`);

--
-- Megkötések a táblához `prices`
--
ALTER TABLE `prices`
  ADD CONSTRAINT `fk_prices_employee` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`employee_id`),
  ADD CONSTRAINT `fk_prices_service` FOREIGN KEY (`service_id`) REFERENCES `services` (`service_id`);

--
-- Megkötések a táblához `product_variant`
--
ALTER TABLE `product_variant`
  ADD CONSTRAINT `fk_product_variant_product` FOREIGN KEY (`pn`) REFERENCES `products` (`pn`);

--
-- Megkötések a táblához `services`
--
ALTER TABLE `services`
  ADD CONSTRAINT `fk_services_salon` FOREIGN KEY (`salon_id`) REFERENCES `salons` (`salon_id`);

--
-- Megkötések a táblához `shifts`
--
ALTER TABLE `shifts`
  ADD CONSTRAINT `fk_shifts_employee` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`employee_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
