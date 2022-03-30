using backEnd_bd.Data.ModelsViews;
using System;
using System.Collections.Generic;
using backEnd_bd.Data.DadosLocais;

namespace backEnd_bd.Application
{
    public class Metodos
    {
        public List<IngressoDTOList> ListarIngressos()
        {
            try
            {
                List<IngressoDTOList> listaIngressos = new List<IngressoDTOList>();
                #region PREENCHENDO OS INGRESSOS PARA A LISTA
                IngressoDTOList ingresso = new IngressoDTOList
                {
                    codigo = Ingressos.ingressoA.codigo,
                    valor = Ingressos.ingressoA.valor
                };
                listaIngressos.Add(ingresso);

                ingresso = new IngressoDTOList
                {
                    codigo = Ingressos.ingressoB.codigo,
                    valor = Ingressos.ingressoB.valor
                };
                listaIngressos.Add(ingresso);

                ingresso = new IngressoDTOList
                {
                    codigo = Ingressos.ingressoC.codigo,
                    valor = Ingressos.ingressoC.valor
                };
                listaIngressos.Add(ingresso);

                ingresso = new IngressoDTOList
                {
                    codigo = Ingressos.ingressoD.codigo,
                    valor = Ingressos.ingressoD.valor
                };
                listaIngressos.Add(ingresso);

                ingresso = new IngressoDTOList
                {
                    codigo = Ingressos.ingressoE.codigo,
                    valor = Ingressos.ingressoE.valor
                };
                listaIngressos.Add(ingresso);
                #endregion

                return listaIngressos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public IngressoDTO ConsultarIngresso(int codigo)
        {
            try
            {
                List<IngressoDTOList> listaIngressos = new List<IngressoDTOList>();
                listaIngressos = ListarIngressos();
                IngressoDTO ingresso = new IngressoDTO();

                List<IngressoDTO> listaingressosDetalhes = new List<IngressoDTO>();
                listaingressosDetalhes.Add(Ingressos.ingressoA);
                listaingressosDetalhes.Add(Ingressos.ingressoB);
                listaingressosDetalhes.Add(Ingressos.ingressoC);
                listaingressosDetalhes.Add(Ingressos.ingressoD);
                listaingressosDetalhes.Add(Ingressos.ingressoE);

                for (int i = 0; i < listaingressosDetalhes.Count; i++)
                {
                    if (listaingressosDetalhes[i].codigo == codigo)
                    {
                        ingresso = listaingressosDetalhes[i];
                    }
                }

                return ingresso;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
