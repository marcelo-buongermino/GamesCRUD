INSERT INTO games (
	id,
	name,
	description,
	category,
	price,
	platform,
	release_date,
	created_at,
	updated_at
)
VALUES (
	1,
	'Elden Ring',
	'Um jogo muito dificil onde voce ira morrer toda hora',
	'RPG',
	250.00,
	'PC',
	'2022-02-25',
	'now()',
	'now()'
),
(
	2,
	'God of war',
	'Um jogo muito legal onde voce ira se aventurar e descer a porrada em geral',
	'Ação',
	150.00,
	'XBOX',
	'2022-02-25',
	'now()',
	'now()'
),
(
	3,
	'Super Mario Kart',
	'Um jogo muito divertido onde voce ira curtir muito com seus amigos',
	'RPG',
	300.00,
	'Switch',
	'2022-02-25',
	'now()',
	'now()'
)
ON CONFLICT DO NOTHING;
