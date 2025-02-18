﻿using Autofac.Extras.Moq;

namespace Newbe.BlogRenderer.Tests;

public abstract class MdRenderProviderTestBase<T> where T : IMdRenderProvider
{
    [Test]
    public async Task Render0X01MdAsync()
    {
        using var autoMock = AutoMock.GetStrict();
        var mdRenderProvider = autoMock.Create<T>();
        var source = await DataHelper.Get0X01ContentAsync();
        var html = await mdRenderProvider.RenderAsync(source);
        await Verify(html, "html");
    }
}