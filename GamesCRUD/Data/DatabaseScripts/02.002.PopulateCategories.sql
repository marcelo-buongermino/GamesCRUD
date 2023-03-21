-- ALTER SEQUENCE categories_id_seq RESTART; --reseta o contador incremental do ID
INSERT INTO categories (name, created_at)
	VALUES ('Ação', NOW()), 
			('Aventura', NOW()), 
			('Corrida', NOW()), 
			('RPG', NOW()), 
			('Luta', NOW()), 
			('Estratégia', NOW());

-- Atribuindo uma categoria a um game
UPDATE games SET category_id = 4 WHERE name = 'Elden Ring';
UPDATE games SET category_id = 1 WHERE name = 'God of war';
UPDATE games SET category_id = 3 WHERE name = 'Super Mario Kart';