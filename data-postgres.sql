insert into "user" (username, password, activated, email) values ('admin', 'admin', true, 'admin@ejemplo.com');
insert into "user" (username, password, activated, email) values ('user', 'user', true, 'user@ejemplo.com');

insert into authority (authority_name) values ('ROLE_USER');
insert into authority (authority_name) values ('ROLE_ADMIN');

insert into user_authority (user_id, authority_name) values (1, 'ROLE_USER');
insert into user_authority (user_id, authority_name) values (1, 'ROLE_ADMIN');
insert into user_authority (user_id, authority_name) values (2, 'ROLE_USER');

insert into "tipocambio" (id, monedaorigen, monedadestino, cambio) values (1, 'PE', 'US', 0.271);
insert into "tipocambio" (id, monedaorigen, monedadestino, cambio) values (2, 'US', 'PE', 3.69);

insert into public."Menus"(id, nombre, url, hijo) values(1, 'inicio', '/', 0);
insert into public."Menus"(id, nombre, url, hijo) values(2, 'usuarios', '/usuarios', 1);
insert into public."Menus"(id, nombre, url, hijo) values(3, 'tarjeta', '/tarjeta', 1);

insert into tarjetacredito(id, titular, numerotarjeta, fecha_expiracion, cvv) values(1, 'Pedro Gonzales', '02/26', '337');
insert into tarjetacredito(id, titular, numerotarjeta, fecha_expiracion, cvv) values(2, 'Maria Marcano', '02/28', '338');
insert into tarjetacredito(id, titular, numerotarjeta, fecha_expiracion, cvv) values(3, 'Talia Rodriguez', '02/26', '339');