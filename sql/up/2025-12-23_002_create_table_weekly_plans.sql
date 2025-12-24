CREATE TABLE IF NOT EXISTS weekly_plans (
    id UUID NOT NULL,
    name VARCHAR(128) NOT NULL,
    sessions_per_week SMALLINT NOT NULL,
    hours_per_session SMALLINT NOT NULL,
    start_time TIME,
    end_time TIME,
    workout_type VARCHAR(128) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_weeky_plans PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS weekly_plan_workouts (
    id UUID NOT NULL,
    weeky_plan_id UUID NOT NULL,
    workout_id UUID NOT NULL,
    CONSTRAINT pk_weekly_plan_workouts PRIMARY KEY(id),
    CONSTRAINT fk_weekly_plan_workout_weekly_plan_id FOREIGN KEY (weekly_plan_id) REFERENCES weekly_plans(id),
    CONSTRAINT fk_weekly_plan_workout_workout_id FOREIGN KEY (workout_id) REFERENCES workout(id)
);