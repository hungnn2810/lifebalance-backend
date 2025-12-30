ALTER TABLE workouts ADD "index" INT NOT NULL DEFAULT 0;
ALTER TABLE workout_steps RENAME COLUMN step_order TO "index";
