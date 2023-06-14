using System;


namespace R5T.O0017
{
    public class GitHubRepositoryOperations : IGitHubRepositoryOperations
    {
        #region Infrastructure

        public static IGitHubRepositoryOperations Instance { get; } = new GitHubRepositoryOperations();


        private GitHubRepositoryOperations()
        {
        }

        #endregion
    }
}
