CREATE TABLE [dbo].[person](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](80) NOT NULL,
	[last_name] [varchar](80) NOT NULL,
	[address] [varchar](100) NOT NULL,
	[gender] [varchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO