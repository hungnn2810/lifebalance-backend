CREATE TABLE IF NOT EXISTS users (
    id UUID NOT NULL,
    email VARCHAR(128) NOT NULL,
    name VARCHAR(128) NOT NULL,
    password VARCHAR(1024) NULL,
    language VARCHAR(8) NOT NULL DEFAULT 'en',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_users PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS user_logins (
    id UUID NOT NULL,
    user_id UUID NOT NULL,
    provider VARCHAR(64) NOT NULL,
    provider_key VARCHAR(128) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_user_logins PRIMARY KEY (id),
    CONSTRAINT fk_user_logins_user_id FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS user_information (
    user_id UUID NOT NULL,
    avatar VARCHAR(1024) NOT NULL,
    age SMALLINT NOT NULL,
    weight SMALLINT NOT NULL,
    height SMALLINT NOT NULL,
    fitness_goals TEXT[] NOT NULL DEFAULT '{}',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_user_information PRIMARY KEY(user_id),
    CONSTRAINT pk_user_information_user_id FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS user_tracking (
    id UUID NOT NULL,
    user_id UUID NOT NULL,
    steps INT NOT NULL DEFAULT 0,
    calories INT NOT NULL DEFAULT 0,
    workout_streak INT NOT NULL DEFAULT 0,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_user_tracking PRIMARY KEY(user_id),
    CONSTRAINT pk_user_tracking_user_id FOREIGN KEY (user_id) REFERENCES users(id)
);