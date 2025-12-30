CREATE TABLE IF NOT EXISTS workouts (
    id UUID NOT NULL,
    name VARCHAR(128) NOT NULL,
    title VARCHAR(256) NOT NULL,
    type VARCHAR(128) NOT NULL,
    notes VARCHAR(1024) NULL,
    benefits TEXT[] NOT NULL DEFAULT '{}',
    estimated_calories INT NOT NULL DEFAULT 0,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_workouts PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS workout_steps (
    id UUID NOT NULL,
    workout_id UUID NOT NULL,
    title VARCHAR(256) NOT NULL,
    step_order SMALLINT NOT NULL DEFAULT 0,
    description VARCHAR(1024) NOT NULL,
    image TEXT NULL,
    video TEXT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_workout_steps PRIMARY KEY (id),
    CONSTRAINT fk_workout_step_workout_id FOREIGN KEY (workout_id) REFERENCES workouts(id)
);