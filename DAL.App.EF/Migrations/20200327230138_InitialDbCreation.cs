using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    WorkoutRoutineId = table.Column<int>(nullable: false),
                    CycleNumber = table.Column<int>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    EndingDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDaysTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDaysTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitsTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Muscles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    MuscleGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Muscles_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRoutines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    WorkoutRoutineId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    RoutineTypeId = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRoutines_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutRoutines_RoutineTypes_RoutineTypeId",
                        column: x => x.RoutineTypeId,
                        principalTable: "RoutineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingWeeks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    TrainingWeekId = table.Column<int>(nullable: false),
                    WeekNumber = table.Column<int>(nullable: false),
                    IsDeload = table.Column<bool>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    EndingDate = table.Column<DateTime>(nullable: true),
                    TrainingCycleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingWeeks_TrainingCycles_TrainingCycleId",
                        column: x => x.TrainingCycleId,
                        principalTable: "TrainingCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Chest = table.Column<int>(nullable: true),
                    Waist = table.Column<int>(nullable: true),
                    Hip = table.Column<int>(nullable: true),
                    Arm = table.Column<int>(nullable: true),
                    BodyFatPercentage = table.Column<int>(nullable: true),
                    AppUserId = table.Column<Guid>(nullable: false),
                    UnitsTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_UnitsTypes_UnitsTypeId",
                        column: x => x.UnitsTypeId,
                        principalTable: "UnitsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyNutritionIntakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false),
                    Protein = table.Column<int>(nullable: true),
                    Fats = table.Column<int>(nullable: true),
                    Carbohydrates = table.Column<int>(nullable: true),
                    AppUserId = table.Column<Guid>(nullable: false),
                    UnitsTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNutritionIntakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyNutritionIntakes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyNutritionIntakes_UnitsTypes_UnitsTypeId",
                        column: x => x.UnitsTypeId,
                        principalTable: "UnitsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetMuscleGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    MuscleGroupId = table.Column<Guid>(nullable: false),
                    ExerciseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetMuscleGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetMuscleGroups_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TargetMuscleGroups_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TrainingWeekId = table.Column<Guid>(nullable: false),
                    TrainingDayTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDays_TrainingDaysTypes_TrainingDayTypeId",
                        column: x => x.TrainingDayTypeId,
                        principalTable: "TrainingDaysTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingDays_TrainingWeeks_TrainingWeekId",
                        column: x => x.TrainingWeekId,
                        principalTable: "TrainingWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercisesInTrainingDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    TrainingDayId = table.Column<Guid>(nullable: false),
                    ExerciseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesInTrainingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisesInTrainingDays_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisesInTrainingDays_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformedExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    NrOfReps = table.Column<int>(nullable: false),
                    NrOfSets = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    AppUserId = table.Column<Guid>(nullable: false),
                    ExerciseId = table.Column<Guid>(nullable: false),
                    UnitsTypeId = table.Column<Guid>(nullable: false),
                    TrainingDayId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformedExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformedExercises_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformedExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformedExercises_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformedExercises_UnitsTypes_UnitsTypeId",
                        column: x => x.UnitsTypeId,
                        principalTable: "UnitsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_AppUserId",
                table: "BodyMeasurements",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_UnitsTypeId",
                table: "BodyMeasurements",
                column: "UnitsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyNutritionIntakes_AppUserId",
                table: "DailyNutritionIntakes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyNutritionIntakes_UnitsTypeId",
                table: "DailyNutritionIntakes",
                column: "UnitsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesInTrainingDays_ExerciseId",
                table: "ExercisesInTrainingDays",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesInTrainingDays_TrainingDayId",
                table: "ExercisesInTrainingDays",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_MuscleGroupId",
                table: "Muscles",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedExercises_AppUserId",
                table: "PerformedExercises",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedExercises_ExerciseId",
                table: "PerformedExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedExercises_TrainingDayId",
                table: "PerformedExercises",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedExercises_UnitsTypeId",
                table: "PerformedExercises",
                column: "UnitsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetMuscleGroups_ExerciseId",
                table: "TargetMuscleGroups",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetMuscleGroups_MuscleGroupId",
                table: "TargetMuscleGroups",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_TrainingDayTypeId",
                table: "TrainingDays",
                column: "TrainingDayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_TrainingWeekId",
                table: "TrainingDays",
                column: "TrainingWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingWeeks_TrainingCycleId",
                table: "TrainingWeeks",
                column: "TrainingCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutines_AppUserId",
                table: "WorkoutRoutines",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutines_RoutineTypeId",
                table: "WorkoutRoutines",
                column: "RoutineTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BodyMeasurements");

            migrationBuilder.DropTable(
                name: "DailyNutritionIntakes");

            migrationBuilder.DropTable(
                name: "ExercisesInTrainingDays");

            migrationBuilder.DropTable(
                name: "Muscles");

            migrationBuilder.DropTable(
                name: "PerformedExercises");

            migrationBuilder.DropTable(
                name: "TargetMuscleGroups");

            migrationBuilder.DropTable(
                name: "WorkoutRoutines");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TrainingDays");

            migrationBuilder.DropTable(
                name: "UnitsTypes");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RoutineTypes");

            migrationBuilder.DropTable(
                name: "TrainingDaysTypes");

            migrationBuilder.DropTable(
                name: "TrainingWeeks");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "TrainingCycles");
        }
    }
}
