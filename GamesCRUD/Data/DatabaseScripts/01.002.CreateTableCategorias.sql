CREATE TABLE IF NOT EXISTS categories (
	id SERIAL PRIMARY KEY,
	name varchar(30) NOT NULL,
	created_at TIMESTAMP WITHOUT TIME ZONE
);

ALTER TABLE games
	DROP COLUMN category,
	ADD COLUMN category_id int,
	ADD FOREIGN KEY(category_id) REFERENCES categories(id);