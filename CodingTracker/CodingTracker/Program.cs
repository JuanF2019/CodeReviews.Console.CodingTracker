using CodingTracker.Repositories;

CodingSessionsRepository.ConnectionString = "Data Source=CodingSessions.db";
CodingSessionsRepository repository = CodingSessionsRepository.Instance;

repository.CreateTable();