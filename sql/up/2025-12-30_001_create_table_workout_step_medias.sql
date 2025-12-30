CREATE TABLE IF NOT EXISTS workout_step_medias (
    id UUID NOT NULL,
    workout_step_id UUID NOT NULL,
    media_type VARCHAR(64) NOT NULL,
    object_key VARCHAR(512) NOT NULL,
    url VARCHAR(512) NOT NULL,
    sort_order SMALLINT NOT NULL DEFAULT 0,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_workout_step_medias PRIMARY KEY (id),
    CONSTRAINT fk_workout_step_media_workout_step_id FOREIGN KEY (workout_step_id) REFERENCES workout_steps(id)
);