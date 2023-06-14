using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0159;
using R5T.T0184;
using R5T.T0186;

namespace R5T.O0017
{
    [ValuesMarker]
    public partial interface IGitHubRepositoryOperations : IValuesMarker
    {
        public async Task Delete_Repository(
            IGitHubRepositoryName repositoryName,
            IGitHubRepositoryOwnerName ownerName,
            ITextOutput textOutput)
        {
            await Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                repositoryName,
                ownerName,
                textOutput,
                Instances.GitHubRepositoryContextOperations.Delete_Repository
            );
        }

        public async Task Create_Repository(
            IGitHubRepositoryName repositoryName,
            IRepositoryDescription repositoryDescription,
            IGitHubRepositoryOwnerName ownerName,
            ITextOutput textOutput)
        {
            await Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                repositoryName,
                ownerName,
                textOutput,
                Instances.GitHubRepositoryContextOperations.Verify_RepositoryDoesNotExist,
                Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(
                    repositoryDescription
                )
            );
        }
    }
}
