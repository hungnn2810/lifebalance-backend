INSERT INTO workouts (
    id,
    code,
    name,
    title,
    type,
    notes,
    benefits,
    estimated_calories,
    "index"
) VALUES (
     '202126a3-f7f9-4468-b3ab-ec6e16a20c14',
     'GYM1',
     'Leg & Glute Workout',
     'Lower Body – Squat Focus',
     'Gym',
     'Tempo 3-1-1 = 3s down – 1s pause – 1s up.
RPE 7–9 for hypertrophy.
Brace = tighten your core as if preparing to be punched.',
     ARRAY[
        'Build lower-body strength',
        'Develop glutes and quadriceps',
        'Improve core stability',
        'Increase calorie burn'
     ],
     450,
     0
);

INSERT INTO workout_steps (
    id,
    code,
    workout_id,
    title,
    "index",
    description
) VALUES (
     '01e423f6-dd98-4cf7-9dc7-597f15907744',
     'GYM1_STEP1',
     '202126a3-f7f9-4468-b3ab-ec6e16a20c14',
     'Standard Warm-up (7–10 minutes)',
     0,
     '3–5 minutes: incline walking or light cycling to raise body temperature.

2–3 minutes:
    - Glute bridge 2×12
    - Bodyweight squat 2×10
     
Ramp-up sets for the main lift:
    - 1 very light set × 10–12 reps
    - 1 moderate set × 5–6 reps'
);

INSERT INTO workout_steps (
    id,
    code,
    workout_id,
    title,
    "index",
    description
) VALUES (
    'a557f1a9-6823-4499-a170-4817c465711e',
    'GYM1_STEP2',
    '202126a3-f7f9-4468-b3ab-ec6e16a20c14',
    'Squat (Goblet / Back Squat)',
    1,
    'Target muscles: quadriceps, glutes, core.

Setup:
- Feet shoulder-width or slightly wider, toes turned out 15–30°
- Weight balanced over mid-foot
- Neutral spine, chest open

Execution:
- Inhale deeply and brace your core
- Descend by pushing hips back and tracking knees over toes
- Lower until you can maintain a neutral spine (thighs parallel is a common reference)
- Drive up by pushing the floor away, keeping knees stable

Coaching cues:
- “Sit down as if onto a chair”
- “Ribs down, core tight”
- “Knees gently out”

Breathing:
- Inhale at the top
- Hold brace during the descent and hardest point
- Exhale near lockout

Sets & Reps:
- Hypertrophy: 3–5 sets × 6–12 reps (RPE 7–9)
- Strength: 4–6 sets × 3–6 reps'
);