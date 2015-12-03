# AutosysProject
Today, the amount of data has grown to a level where it is starting to challenge researchers who need to
extract the best available research on a specific question. As a result, researchers apply systematic studies
on big data sets where they exploit metadata to classify subsets with useful data. This requires smart
data processing tools that can use metadata to narrow down relevant research data. The purpose of such
a systematic review is to sum up the best available research on a specific question. This can be achieved by
combining the results of several studies. In this regard, the system in this project is comprised of two parts,
client and server side. Our system scope is restricted to the server side and shall support the configuration
of summarized research data relevant to a given research question.

#1.2 Scope of the System
The server shall provide teams with tools to conduct secondary studies (SMS or SLR). It should support
activities of planning and conducting a review distributed in a research team. The server shall make sure
that all data is stored for use in setting up a study configuration requested by the client. The system should
be able to import information from a BibTeX file to a database. The reason is we want to be able to populate
our database with existing data. Security matters (e.g. user authentication) are not taken into primary
account due to the scope of the project. In order for the system to fulfill the previously described purpose, it
has to support the tasks described in the "Proposed System" section. Among these, the system shall support
management of distributed research systems to work on a study. The reviewers should be able to export
data sets and filter them with inclusion and exclusion criteria. Finally, the system should allow specific sets
of data to be reviewed and screened by specific members of a research team.

#1.3 Objectives and Success Criteria of the Project
The system should be easy to deploy and install. It should include an installation and user manual used to
describe how to configure and prepare research papers for screening. It should be easy and quick to distribute
relevant data and the overview should outcompete the one achieved in other third-party programs such as
e.g. Excel. The system should define rules for which data goes to whom to achieve a successful screening of
paper and efficient data extraction. The yellow system has to provide a user interface from which the blue
team can extract data based on user roles and rules. The system has succeeded if users in the blue team can
query the yellow system for relevant studies and tasks based on a given study configuration. Specifically, the
yellow system should collect research and aggregate stacks of research material based on a research question.
The blue system should then efficiently be able to extract a subset of primary studies provided from the
screening of the search hits in the yellow system. The configured data may then be used by reviewers in
the blue system (visualize, sort, export and categorize). Finally, the system should be able to replicate an
existing study.