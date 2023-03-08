CREATE TABLE IF NOT EXISTS public.games
(
    id integer NOT NULL DEFAULT nextval('games_id_seq'::regclass),
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description character varying(300) COLLATE pg_catalog."default",
    category character varying(30) COLLATE pg_catalog."default",
    price numeric(4,2) NOT NULL,
    platform character varying(20) COLLATE pg_catalog."default" NOT NULL,
    release_date date NOT NULL,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    CONSTRAINT games_pkey PRIMARY KEY (id)
)