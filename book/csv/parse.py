import pandas as pd

 df = pd.read_csv('/home/exiled/projects/chess/csv/chess_openings.csv')


 print(df.head())

 grouped_openings = df.groupby(['First Move', 'Variation']).agg(list).reset_index()

 print(df.grouped_openings.head())


