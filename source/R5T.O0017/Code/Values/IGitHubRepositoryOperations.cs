using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0159;
using R5T.T0180;
using R5T.T0184;
using R5T.T0186;
using R5T.T0198;
using R5T.T0198.Extensions;
using R5T.T0200;


namespace R5T.O0017
{
    [ValuesMarker]
    public partial interface IGitHubRepositoryOperations : IValuesMarker
    {
        public Task<bool> Is_Private(IPath withinRepositoryPath)
        {
            var repositoryDirectoryPath = Instances.GitOperations.Get_RepositoryDirectoryPath(withinRepositoryPath);

            var output = this.Is_Private(repositoryDirectoryPath);
            return output;
        }

        public Task<bool> Is_Private(IRepositoryDirectoryPath repositoryDirectoryPath)
        {
            var repositoryUrl = Instances.GitOperations.Get_RepositoryUrl(repositoryDirectoryPath);

            return this.Is_Private(repositoryUrl);
        }

        public Task<bool> Is_Private(IRepositoryUrl repositoryUrl)
        {
            var output = Instances.GitHubOperator.Is_Private(repositoryUrl.Value);
            return output;
        }

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
