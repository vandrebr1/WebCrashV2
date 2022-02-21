/*MENOR GANHO MENOR QUANTIDADE DE JOGOS 95% VITORIAS*/
SELECT TOP (1000) Id, Pattern, Diferenca, Acertos, Erros, TotalApostas, Ganhos, QuantidadeJogos, ProporcaoAcertosErros, NumeroCaracteres, ValorEmDecimal, Ganhos * ProporcaoAcertosErros,
ProporcaoGanhosApostas
  FROM [WebCrashV2].[dbo].[Analises]
  --where  ProporcaoAcertosErros >= 3.14159265
  order by  ProporcaoGanhosApostas desc, Diferenca desc



--MAIOR GANHO MAIOR QTO DE JOGOS 80% VITORIA
SELECT TOP (1000) Id, Pattern, Diferenca, Acertos, Erros, TotalApostas, Ganhos, QuantidadeJogos, ProporcaoAcertosErros, NumeroCaracteres, ValorEmDecimal, Ganhos * ProporcaoAcertosErros,
ProporcaoGanhosApostas
  FROM [WebCrashV2].[dbo].[Analises]
  where  ProporcaoAcertosErros >= 3.14159265
  order by Ganhos desc

      SELECT  ROUND(Analises.ProporcaoGanhosApostas,0,1), [Analises].[Pattern],  [Analises].Diferenca, [Analises].Acertos, [Analises].Erros, [Analises].TotalApostas,  [Analises].Ganhos,
	 [Analises].ProporcaoAcertosErros,  [Analises].ProporcaoGanhosApostas,  [Analises].NumeroCaracteres,  [Analises].ValorEmDecimal,
	  [Analises].Diferenca -  ANTES.Diferenca As DifAntesDepois
  FROM [WebCrashV2].[dbo].[Analises]
  INNER JOIN (SELECT *
			FROM [WebCrashV2].[dbo].[Analises]
			WHERE DtAnalisado < '2022-02-13 19:48:00.967') AS ANTES
  ON [Analises].Pattern = ANTES.Pattern
  WHERE [Analises].DtAnalisado >= '2022-02-13 19:48:00.967' 
  ORDER BY [Analises].ProporcaoGanhosApostas desc

  /**************PROXIMO PATTER PROPORCAOGANHOS = 2 ******************/
  SELECT ROUND(RESULT.ProporcaoGanhosApostas,0,1), SUM(DifAntesDepois) FROM (
    SELECT  [Analises].[Pattern],  [Analises].Diferenca, [Analises].Acertos, [Analises].Erros, [Analises].TotalApostas,  [Analises].Ganhos,
	 [Analises].ProporcaoAcertosErros,  [Analises].ProporcaoGanhosApostas,  [Analises].NumeroCaracteres,  [Analises].ValorEmDecimal,
	  [Analises].Diferenca -  ANTES.Diferenca As DifAntesDepois
  FROM [WebCrashV2].[dbo].[Analises]
  INNER JOIN (SELECT *
			FROM [WebCrashV2].[dbo].[Analises]
			WHERE DtAnalisado < '2022-02-13 19:48:00.967') AS ANTES
  ON [Analises].Pattern = ANTES.Pattern
  WHERE [Analises].DtAnalisado >= '2022-02-13 19:48:00.967' ) as RESULT
  GROUP BY ROUND(RESULT.ProporcaoGanhosApostas,0,1)
  ORDER BY SUM(DifAntesDepois) DESC
  --2.46343341

  SELECT  [Analises].[Pattern],  [Analises].Diferenca, [Analises].Acertos, [Analises].Erros, [Analises].TotalApostas,  [Analises].Ganhos,
	 [Analises].ProporcaoAcertosErros,  [Analises].ProporcaoGanhosApostas,  [Analises].NumeroCaracteres,  [Analises].ValorEmDecimal,
	  [Analises].Diferenca -  ANTES.Diferenca As DifAntesDepois
  FROM [WebCrashV2].[dbo].[Analises]
  INNER JOIN (SELECT *
			FROM [WebCrashV2].[dbo].[Analises]
			WHERE DtAnalisado < '2022-02-13 19:48:00.967') AS ANTES
  ON [Analises].Pattern = ANTES.Pattern
  WHERE [Analises].DtAnalisado >= '2022-02-13 19:48:00.967' AND [Analises].ProporcaoGanhosApostas BETWEEN 2 AND 2.99999

  /************************************/
  


  SELECT *, (SELECT SUM([Valor])
  FROM [WebCrashV2].[dbo].[Contabilidade]
  where DataHora >= '2022-02-18 17:01:20.390' AND Id <=Cont.Id)
FROM [WebCrashV2].[dbo].[Contabilidade] AS Cont
where DataHora >= '2022-02-18 17:01:20.390'




SELECT *, IIF(PrimeiroBin=0 AND SegundoBin=1,1,-1) FROM (
	SELECT Primeiro.Id As PId, Primeiro.Multiplicador As PMult, 
			Segundo.Id As SId, Segundo.Multiplicador As SMult,
		IIF(Primeiro.Multiplicador >=2,1,IIF(Primeiro.Multiplicador>-1,0,9)) PrimeiroBin,
		IIF(Segundo.Multiplicador >=2,1,IIF(Segundo.Multiplicador>-1,0,9)) SegundoBin
	FROM TelaInformacoes Primeiro
		LEFT JOIN TelaInformacoes Segundo
		ON Primeiro.Id+1 = Segundo.Id
) AS Result
WHERE PrimeiroBin = 0


SELECT *, (SELECT SUM([Valor])
			FROM [WebCrashV2].[dbo].[Contabilidade]
			where DataHora >= '2022-02-14 19:57:03.850' AND Id <=Cont.Id)
FROM [WebCrashV2].[dbo].[Contabilidade] AS Cont
where DataHora >= '2022-02-14 19:57:03.850'


SELECT *
FROM [WebCrashV2].[dbo].[Contabilidade] AS Cont
INNER JOIN PatternsJogar
ON Cont.PatternApostado = PatternsJogar.Pattern
where DataHora >= '2022-02-14 19:57:03.850' AND GeradoPeloComputador = 0

