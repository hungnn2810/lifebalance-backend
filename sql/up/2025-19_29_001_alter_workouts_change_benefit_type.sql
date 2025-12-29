ALTER TABLE workouts ALTER COLUMN benefits TYPE _text USING benefits::_text;
ALTER TABLE workouts ALTER COLUMN benefits SET DEFAULT '{}'::text[];
