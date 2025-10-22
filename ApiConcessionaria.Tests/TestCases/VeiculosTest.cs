using ApiConcessionaria.Services.Requests;
using ApiConcessionaria.Services.Responses;
using ApiConcessionaria.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiConcessionaria.Tests.TestCases
{
    /// <summary>
    /// Classe de teste para os serviços de veiculos da API
    /// </summary>
    public class VeiculosTest
    {
        private readonly HttpClient _httpClient;
        private readonly Faker _faker;

        public VeiculosTest()
        {
            _httpClient = new HttpClient();
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task<VeiculoGetResponse> Post_Veiculos_Return_Ok()
        {
            #region criando os dados de requisição

            var request = new VeiculoPostRequest
            {
                Nome = _faker.Vehicle.Model(),
                Marca = _faker.Vehicle.Manufacturer(),
                Preco = decimal.Parse(_faker.Commerce.Price()),
                AnoVeiculo = _faker.Random.Number(2001, 2023)
            };

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PostAsync($"{ApiHelper.Endpoint}/Veiculo", ApiHelper.CreateContent(request));
            var response = ApiHelper.CreateResponse<VeiculoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            response.IdVeiculo.Should().NotBeEmpty();
            response.Nome.Should().Be(request.Nome);
            response.Preco.Should().Be(request.Preco);
            response.AnoVeiculo.Should().Be(request.AnoVeiculo);

            #endregion

            return response;
        }

        [Fact]
        public async Task Put_Veiculos_Return_Ok()
        {
            #region Cadastrando e Modificando os dados de um veiculo

            var request = await Post_Veiculos_Return_Ok();
            request.Nome = _faker.Vehicle.Model();
            request.Preco = decimal.Parse(_faker.Commerce.Price());
            request.AnoVeiculo = _faker.Random.Number(2001, 2023);

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PutAsync($"{ApiHelper.Endpoint}/Veiculo", ApiHelper.CreateContent(request));
            var response = ApiHelper.CreateResponse<VeiculoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdVeiculo.Should().NotBeEmpty();
            response.Nome.Should().Be(request.Nome);
            response.Marca.Should().Be(request.Marca);
            response.Preco.Should().Be(request.Preco);
            response.AnoVeiculo.Should().Be(request.AnoVeiculo);

            #endregion
        }

        [Fact]
        public async Task Put_Veiculos_Return_UnprocessableEntity()
        {
            #region

            var request = new VeiculoPutRequest
            {
                IdVeiculo = Guid.NewGuid(),
                Nome = _faker.Vehicle.Model(),
                Preco = decimal.Parse(_faker.Commerce.Price()),
                AnoVeiculo = _faker.Random.Number(2001, 2023)
            };

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PutAsync($"{ApiHelper.Endpoint}/Veiculo", ApiHelper.CreateContent(request));

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.UnprocessableEntity);

            #endregion
        }

        [Fact]
        public async Task Delete_Veiculos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Veiculos_Return_Ok();
            var result = await _httpClient.DeleteAsync($"{ApiHelper.Endpoint}/Veiculo/{request.IdVeiculo}");
            var response = ApiHelper.CreateResponse<VeiculoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdVeiculo.Should().Be(request.IdVeiculo);
            response.Nome.Should().Be(request.Nome);
            response.Marca.Should().Be(request.Marca);
            response.Preco.Should().Be(request.Preco);
            response.AnoVeiculo.Should().Be(request.AnoVeiculo);

            #endregion
        }

        [Fact]
        public async Task Delete_Veiculos_Return_UnprocessableEntity()
        {
            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.DeleteAsync($"{ApiHelper.Endpoint}/Veiculo/{Guid.NewGuid()}");

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.UnprocessableEntity);

            #endregion
        }

        [Fact]
        public async Task GetAll_Veiculos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Veiculos_Return_Ok();
            var result = await _httpClient.GetAsync($"{ApiHelper.Endpoint}/Veiculo");
            var response = ApiHelper.CreateResponse<List<VeiculoGetResponse>>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response
                .Should()
                .NotBeEmpty();

            response
                .FirstOrDefault(res => res.IdVeiculo.Equals(request.IdVeiculo))
                .Should().NotBeNull();

            #endregion
        }

        [Fact]
        public async Task GetById_Veiculos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Veiculos_Return_Ok();
            var result = await _httpClient.GetAsync($"{ApiHelper.Endpoint}/Veiculo/{request.IdVeiculo}");
            var response = ApiHelper.CreateResponse<VeiculoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdVeiculo.Should().Be(request.IdVeiculo);
            response.Nome.Should().Be(request.Nome);
            response.Marca.Should().Be(request.Marca);
            response.Preco.Should().Be(request.Preco);
            response.AnoVeiculo.Should().Be(request.AnoVeiculo);

            #endregion
        }
    }
}
