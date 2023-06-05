namespace NGitLab.Models
{
    public class RepositoryChangelogOptions
    {
        /// <summary>
        /// The version to generate the changelog for. The format must follow semantic versioning.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The branch to commit the changelog changes to. Defaults to the project’s default branch.
        /// </summary>
        public string Branch { get; set; }

        //
        //        public bool Recursive { get; set; }
        //
        //        public uint? PerPage { get; set; }
        //        config_file string no  Path to the changelog configuration file in the project’s Git repository.Defaults to.gitlab/changelog_config.yml.
        //date datetime    no The date and time of the release. Defaults to the current time.

        /// <summary>
        /// The file to commit the changes to.Defaults to CHANGELOG.md.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// he SHA of the commit that marks the beginning of the range of commits to include in the changelog. This commit isn’t included in the changelog.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The commit message to use when committing the changes.Defaults to Add changelog for version X, where X is the value of the version argument.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The SHA of the commit that marks the end of the range of commits to include in the changelog. This commit is included in the changelog. Defaults to the branch specified in the branch attribute.Limited to 15000 commits unless the feature flag changelog_commits_limitation is disabled.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The Git trailer to use for including commits. Defaults to Changelog.Cas
        /// </summary>
        public string Trailer { get; set; }
    }
}
